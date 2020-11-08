Option Strict Off
Option Explicit On

Imports System.Data.SqlServerCe
Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Word

Module modAnagram
    Public aMSWord As Word.Application 'Microsoft Word
    Public txtAnagramTextOnly As String 'Text is formatted in text box to suit game
    Public lstHumanHeight As Integer
    ReadOnly aCombCmd As New SqlCeCommand
    'used in recursive recombine so that's why it's declared out here
    Public userBreak As Boolean 'CmdSearch during the searching says 'stop' and clicking on it interrupts the search
    Public Const aSearchButtonStr As String = "Search for words"
    Dim currWord As String 'used in recursive recombine: current arrangement of letters
    Dim solutionFound As Boolean = False 'used in checking for boggle solutions checknextletter
    Dim letters(25, 1) As Integer 'Letter frequency

    Private Function Adjacent(lastI As Integer, i As Integer) As Boolean
        'In a 4 x 4 grid
        Dim xl As Integer = GetX(lastI, 4)
        Dim yl As Integer = GetY(lastI, 4)
        Dim xi As Integer = GetX(i, 4)
        Dim yi As Integer = GetY(i, 4)
        Dim distance As Double = Math.Sqrt((xl - xi) ^ 2 + (yl - yi) ^ 2)        'Distance between 2 points is sqrt((xl-xi)^2 + (yl-yi)^2)
        Adjacent = (distance < 2)
    End Function

    Public Function Anagram(ByRef s1 As String, ByRef s2 As String) As Boolean
        'Called from FindWord
        'Returns true if all the letters in the first word are in the second.
        'for each s1 letter delete it from a temporary string s if a letter in s1 can be found then not an anagram
        Dim s As String 'temporary
        Dim i As Short 'each letter in s1
        Dim p As Short 'position of letter in s2

        s = s2 'set up temporary string s
        Anagram = True 'assume it will be an anagram
        For i = 1 To Len(s1) 'for each letter in s1
            p = InStr(s, Mid(s1, i, 1)) 'look for character s1[i] in s
            If p > 0 Then 'if the letter is found
                s = Left(s, p - 1) & Right(s, Len(s) - p) 'remove it
            Else 'if the letter not found then it's not an anagram.
                Anagram = False
                Exit Function
            End If
        Next i
    End Function

    Public Function CheckAdjacentNoOverlap(letterPool As String, aWord As String) As Boolean
        'This assumes that the word exists as an anagram in the letter pool
        'See solutionFound global
        Dim used(16) As String 'already used position list
        Dim o As Integer ' occurrence 
        Dim letter As String
        Dim i As Integer 'index into grid
        Dim wordLetterPos As Integer = 0 'index into word

        CheckAdjacentNoOverlap = False
        letter = aWord.Substring(wordLetterPos, 1) 'first letter Of word
        For o = 1 To CountCharacter(letterPool, letter) ' For each oth occurrence of first letter Of word
            i = GetNthIndex(letterPool, letter, o) 'Find(oth occurrence Of lth) letter in the pool (0 based index)
            used(i) = letter
            If CheckNextLetter(letterPool, used, i, aWord, wordLetterPos + 1) Then
                CheckAdjacentNoOverlap = True
                'DebugPrintUsed(used)
                Exit Function
            Else
                used(i) = "" 'undo in prep for checking next occurence
            End If
        Next o
    End Function

    Public Function CheckNextLetter(letterPool As String, used() As String, lastI As Integer, aWord As String, wordLetterPos As Integer) As Boolean
        Dim letter As String 'letter in word
        Dim o As Integer ' occurrence 
        Dim i As Integer 'index into grid

        CheckNextLetter = False
        If wordLetterPos > aWord.Length - 1 Then
            CheckNextLetter = True 'No more letters to check
        Else
            letter = aWord.Substring(wordLetterPos, 1) 'first letter Of word
            For o = 1 To CountCharacter(letterPool, letter) ' For each oth occurrence of first letter Of word
                i = GetNthIndex(letterPool, letter, o) 'Find(oth occurrence Of lth) letter in the pool
                If Adjacent(lastI, i) And Free(used, i) Then
                    used(i) = letter
                    If CheckNextLetter(letterPool, used, i, aWord, wordLetterPos + 1) Then
                        CheckNextLetter = True
                        Exit Function
                    Else
                        used(i) = "" 'undo in prep for checking next occurence
                    End If
                End If
            Next o
        End If
    End Function

    Public Sub CheckWord16()
        'This routine finds words in letter pool with minimum length and addition connectedness constraint
        Dim letterPool As String
        Dim aCmbiCmd As New SqlCeCommand 'for interating through combinations
        Dim aCmbiDR As SqlCeDataReader 'for iterating through combinations
        Dim aWord As String
        Dim minLen As Integer
        Dim maxLen As Integer

        letterPool = My.Forms.FrmAnagram.TxtAnagram.Text
        minLen = My.Settings.MinLen16
        maxLen = 16
        'for each word in word list
        Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
            aCmbiCmd.Connection = aConnection
            aCmbiCmd.CommandType = CommandType.Text 'populate data reader
            aConnection.Open()
            aCmbiCmd.CommandText = "SELECT word FROM tblWord" 'source
            aCmbiDR = aCmbiCmd.ExecuteReader
            While aCmbiDR.Read And Not userBreak
                aWord = aCmbiDR("word")
                'check if word meets basic constraints
                If aWord.Length >= minLen And aWord.Length <= maxLen Then
                    If CheckLettersExist(letterPool, aWord) Then 'check if letters are present
                        If CheckAdjacentNoOverlap(letterPool, aWord) Then 'check letters are connected with no overlap
                            My.Forms.FrmAnagram.LstFound.Items.Add(aWord)
                            My.Forms.FrmAnagram.LstFound.TopIndex = My.Forms.FrmAnagram.LstFound.Items.Count - 1
                            My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
                            System.Windows.Forms.Application.DoEvents()
                        End If
                    End If
                End If
            End While
        End Using
    End Sub

    Public Sub CheckWord9()
        'This routine finds all words in letter pool with optional must contain and minimum length constraints
        Dim letterPool As String
        Dim aCmbiCmd As New SqlCeCommand 'for interating through combinations
        Dim aCmbiDR As SqlCeDataReader 'for iterating through combinations
        Dim aWord As String
        Dim minLen As Integer
        Dim maxLen As Integer
        Dim mustContain As String = ""

        letterPool = My.Forms.FrmAnagram.TxtAnagram.Text
        If My.Forms.FrmAnagram.MnuToolsGen9.Checked Then
            minLen = My.Settings.MinLen9
            maxLen = 9
            If My.Settings.MustContain9 > 0 Then
                mustContain = letterPool.Substring(My.Settings.MustContain9 - 1, 1)
            End If
        Else
            minLen = 1
            maxLen = letterPool.Length
        End If
        'for each word in word list
        Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
            aCmbiCmd.Connection = aConnection
            aCmbiCmd.CommandType = CommandType.Text 'populate data reader
            aConnection.Open()
            aCmbiCmd.CommandText = "SELECT word FROM tblWord" 'source
            aCmbiDR = aCmbiCmd.ExecuteReader
            My.Forms.FrmAnagram.LstFound.Items.Clear()
            My.Forms.FrmAnagram.LstHuman.Items.Clear()
            My.Forms.FrmAnagram.TxtNewWord.Text = ""
            While aCmbiDR.Read And Not userBreak
                aWord = aCmbiDR("word")
                'check if word meets basic constraints
                If aWord.Length >= minLen And aWord.Length <= maxLen And (mustContain = "" Or aWord.Contains(mustContain)) Then
                    If CheckLettersExist(letterPool, aWord) Then 'check if letters are present
                        My.Forms.FrmAnagram.LstFound.Items.Add(aWord)
                        My.Forms.FrmAnagram.LstFound.TopIndex = My.Forms.FrmAnagram.LstFound.Items.Count - 1
                        My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
                        System.Windows.Forms.Application.DoEvents()
                    End If
                End If
            End While
        End Using
    End Sub

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        'https://stackoverflow.com/questions/5193893/count-specific-character-occurrences-in-a-string
        value.Count()
        Return value.Count(Function(c As Char) c = ch) 'LINQ extension method -- the predicate function tests each element c for the condition specifiedn ... in this case that c = ch
    End Function

    Private Function Free(used() As String, i As Integer) As Boolean
        Free = (used(i) = "")
    End Function

    Public Function CheckLettersExist(ByVal letterPool As String, aWord As String) As Boolean
        'Check all letters in aWord are available in letterPool        'teststring = mixed letters
        CheckLettersExist = True
        For Each letter As Char In aWord 'for each letter in word
            If letterPool.Contains(letter) Then 'check for letter in teststring
                letterPool = Replace(letterPool, letter, "", 1, 1) 'if present, remove from teststring
            Else
                CheckLettersExist = False
                Exit Function
            End If
        Next 'if all present then word is possible
    End Function

    Public Sub DoAnagram()
        'Check each word against letter pool to find valid words to add to list
        Try
            'tblCombination contains a record for each combination of all letters
            'DoStage1() 'find all combinations and put them into tblCombination
            'DoStage2() 'find words and put them into tblResult
            CheckWord9()
        Catch ex As Exception
            MsgBox("doAnagram: " & ex.Message)
        End Try
    End Sub

    Public Sub DoBogram()
        'Check each word against letter pool to find valid words to add to list
        Try
            CheckWord16()
        Catch ex As Exception
            MsgBox("doBogram: " & ex.Message)
        End Try
    End Sub

    Public Sub EmptyDatabase()
        'Deletes all records from all tables
        'Called from doStage1 and also on exiting the program before compressing
        'WD Syntax of delete differs from Access and there is an issue with using truncate with sqlCE compact edition
        Dim aCommand As New SqlCeCommand

        Try
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aCommand.Connection = aConnection
                aCommand.CommandType = CommandType.Text 'sql update command see below
                aConnection.Open()
                aCommand.CommandText = "DELETE tblCombination" '"truncate table tblCombination" '"Delete * from tblCombination"
                aCommand.ExecuteNonQuery()
                aCommand.CommandText = "DELETE tblCombine" '"truncate table tblCombine" '"Delete * from tblCombine"
                aCommand.ExecuteNonQuery()
                aCommand.CommandText = "DELETE tblResult" '"truncate table tblResult" '"Delete * from tblResult"
                aCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("emptyDatabase: " & ex.Message)
        End Try
    End Sub

    Public Function Factorial(ByRef n As Integer) As Integer
        'Called from TxtAnagram_TextChanged
        'Calculates permutations e.g. abc = 3! 3*2=6 abc acb cba cab bca bac
        Factorial = 0
        Try
            If n > 1 Then
                Factorial = n * Factorial(n - 1)
            Else
                Factorial = n
            End If
        Catch ex As Exception
            MsgBox("Factorial: " & Err.Description)
        End Try
    End Function

    Public Sub FindWordCombines(ByRef s As String)
        'Try each combination of words to see if all letters can be used
        's (from TxtAnagram) are all the letters to rearrange
        Dim s1 As String = "" 'a pair of words

        Try
            My.Forms.FrmAnagram.LstHuman.Items.Clear()
            My.Forms.FrmAnagram.TxtNewWord.Text = ""
            My.Forms.FrmAnagram.StatusBar1.Text = "Finding word combinations..."
            My.Forms.FrmAnagram.TimeLimit.Interval = 15000
            My.Forms.FrmAnagram.TimeLimit.Start()
            Cursor.Current = Cursors.WaitCursor
            FindWords(s, s1)
            My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstHuman.Items.Count & " combinations found."
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox("FindWordCombines: " & ex.Message)
        End Try

    End Sub

    Public Function FindWord(ByRef s As String, ByRef s1 As String) As String
        'Called by FindWordCombines
        'Find another tblResult word that is not the same as s1
        's is all the letters to rearrange (TxtAnagram)
        's1 is a result word
        Dim aResultCommand As New SqlCeCommand
        Dim aResultDR As SqlCeDataReader
        Dim s2 As String
        Dim sLen As Short

        FindWord = ""
        Try
            sLen = Len(s)
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aResultCommand.Connection = aConnection 'Check all the other result words
                aResultCommand.CommandText = "SELECT result FROM tblResult WHERE result <> '" & s1 & "'"
                aResultCommand.CommandType = CommandType.Text
                aConnection.Open()
                aResultDR = aResultCommand.ExecuteReader
                Do While aResultDR.Read()
                    s2 = s1 & aResultDR("Result").ToString 'join two result words
                    If Len(s2) = sLen Then 'see if we've used all the letters
                        If Anagram(s2, s) Then 'if we have check that the new combination is an anagram
                            FindWord = s1 & " " & aResultDR("Result").ToString 'return the combination
                        End If
                    End If
                Loop
            End Using
        Catch ex As Exception
            MsgBox("FindWord: " & ex.Message)
        End Try
    End Function

    Public Function FindWords(ByRef s As String, ByVal s1 As String) As String
        'Called by FindWordCombines
        'Find another tblResult word that is not the same as s1
        's is all the letters to rearrange (TxtAnagram)
        's1 is a result word
        Dim s2 As String
        Dim sLen As Short

        FindWords = ""
        If userBreak Then 'timed out
            'MsgBox("Timed out before completing the search for combinations... Search string too long?")
            Exit Function
        End If
        sLen = Len(s)
        For Each word As String In My.Forms.FrmAnagram.LstFound.Items
            s2 = s1 & " " & word 'join two result words
            If Len(Replace(s2, " ", "")) = sLen Then 'see if we've used all the letters
                If Anagram(Replace(s2, " ", ""), s) Then 'if we have check that the new combination is an anagram
                    My.Forms.FrmAnagram.LstHuman.Items.Add(s2)
                    My.Forms.FrmAnagram.LstHuman.TopIndex = My.Forms.FrmAnagram.LstHuman.Items.Count - 1
                    My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstHuman.Items.Count & " combinations found... "
                End If
                System.Windows.Forms.Application.DoEvents()
            ElseIf Len(s2) < sLen Then
                FindWords = FindWords(s, s2)
            Else
                FindWords = ""
            End If
        Next
    End Function

    Public Sub GetLetterFrequencies()
        Dim aCmbiCmd As New SqlCeCommand 'for interating through combinations
        Dim aCmbiDR As SqlCeDataReader 'for iterating through combinations
        Dim aWord As String
        Dim mustContain As String = ""
        Dim aAscBase = Asc("a")
        Dim i As Integer

        Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
            aCmbiCmd.Connection = aConnection
            aCmbiCmd.CommandType = CommandType.Text 'populate data reader
            aConnection.Open()
            aCmbiCmd.CommandText = "SELECT word FROM tblWord" 'source
            aCmbiDR = aCmbiCmd.ExecuteReader
            While aCmbiDR.Read And Not userBreak
                aWord = aCmbiDR("word")
                For Each aLetter As String In aWord
                    letters(Asc(LCase(aLetter)) - aAscBase, 0) += 1
                Next
            End While
        End Using
        letters(0, 1) = letters(0, 0)
        For i = 0 To 24
            letters(i + 1, 1) += (letters(i, 1) + letters(i, 0)) 'get a cumulative total
        Next
        'For i = 0 To 25
        '    Debug.Print(Chr(Asc("a") + i) & " " & letters(i, 0).ToString() & " " & letters(i, 1).ToString())
        'Next
    End Sub

    Public Function GetNthIndex(s As String, t As Char, n As Integer) As Integer
        Dim count As Integer = 0
        For i As Integer = 0 To s.Length - 1
            If s(i) = t Then
                count += 1
                If count = n Then
                    Return i
                End If
            End If
        Next
        Return -1
    End Function

    Public Function GetX(i As Integer, xDim As Integer) As Integer
        'return an index into the array where y = int(i / xDim) i.e. 0, 1, 2, 3 -> y = 0 and x = i mod xDim so i 6 -> y = 1, x = 2 (-1 is not found)
        GetX = i Mod xDim
    End Function

    Public Function GetY(i As Integer, xDim As Integer) As Integer
        'return an index into the array where y = int(i / xDim) i.e. 0, 1, 2, 3 -> y = 0 and x = i mod xDim so i 6 -> y = 1, x = 2 (-1 is not found)
        GetY = Int(i / xDim)
    End Function

    Public Function GetRandomLetter() As String
        'Generate a random number in range letters with > frequency have more likelihood of being chosen
        Randomize()
        Dim value As Integer = CInt(Int((letters(25, 1) * Rnd()))) 'letters(25, 1) is the sum total of all the letter counts
        Dim i As Integer = 0
        While value > letters(i, 1) 'find the letter in the range matching the random value
            i += 1
        End While
        GetRandomLetter = Chr(Asc("a") + i)
    End Function

    Public Sub Gen16LetterPuzzle()
        Dim letterPool As String = ""

        GetLetterFrequencies()
        For i As Integer = 1 To 16
            letterPool += GetRandomLetter()
            If Right(letterPool, 1) = "q" Then
                If letterPool.Contains("u") Then
                    letterPool.Remove(letterPool.IndexOf("u"))
                    letterPool += "u"
                Else
                    If i < 16 Then
                        i += 1
                        letterPool += "u"
                    End If
                End If
            End If
        Next
        My.Forms.FrmAnagram.TxtAnagram.Text = letterPool '"yluuxzyswitywulq" '
    End Sub

    Public Sub Gen9LetterPuzzle()
        'http://www.yougowords.com/9-letters-12
        Randomize()
        Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim text = IO.File.ReadAllText(AppPath + "nineletterwords.csv")
        Dim words = text.Split(vbCr) 'note: leaves vbLF at start of each line
        Dim value As Integer = CInt(Int((words.Length * Rnd())))
        My.Forms.FrmAnagram.TxtAnagram.Text = MixUpWord(words(value))
    End Sub

    Public Function MixUpWord(v As String) As String
        Dim a As Short
        Dim b As Short
        Dim c As String

        v = v.Replace(vbLf, "")
        For i = 1 To 100
            a = CInt(Int(v.Length * Rnd()))
            b = CInt(Int(v.Length * Rnd()))
            If a <> b Then
                c = v.Substring(a, 1)
                v = v.Insert(a, v.Substring(b, 1))
                v = v.Remove(a + 1, 1)
                v = v.Insert(b, c)
                v = v.Remove(b + 1, 1)
            End If
        Next
        MixUpWord = v
    End Function

    Public Sub PopulateWordList()
        Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
        Dim SQL As String = ""

        Try
            My.Forms.FrmAnagram.StatusBar1.Text = "Importing wordlist.csv"
            Cursor.Current = Cursors.WaitCursor

            aCombCmd.Connection = aConnection
            aCombCmd.CommandType = CommandType.Text 'sql update command see below
            aConnection.Open()
            aCombCmd.CommandText = "DROP TABLE tblWord;"
            aCombCmd.ExecuteNonQuery()
            aCombCmd.CommandText = "CREATE TABLE [tblWord] ([Id] int IDENTITY (1,1) Not NULL, [Word] nvarchar(50) Not NULL);"
            aCombCmd.ExecuteNonQuery()
            aCombCmd.CommandText = "ALTER TABLE [tblWord] ADD CONSTRAINT [PK_tblWord] PRIMARY KEY ([WORD])"
            aCombCmd.ExecuteNonQuery()

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(AppPath + "wordlist.csv")
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        aCombCmd.CommandText = "INSERT INTO tblWord (word) VALUES ('" & currentRow(1) & "');"
                        aCombCmd.ExecuteNonQuery()
                        Application.DoEvents()
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using
            aConnection.Close()

        Catch ex As Exception
            MsgBox("PopulateWordList: " & ex.Message)
        End Try

        My.Forms.FrmAnagram.StatusBar1.Text = "list imported."
        Cursor.Current = Cursors.Default

    End Sub

    Public Function ShiftRight(ByVal a As String) As String
        'Called by recombine
        'move all the letters of the 'word' right
        'move the last letter to the start of the 'word'
        ShiftRight = Right(a, 1) & Left(a, Len(a) - 1)
    End Function

    Public Function StrCmp(ByRef s1 As String, ByRef s2 As String) As Short
        'Returns the position of the first diff between to strings
        '0 indicates no difference
        Dim i As Short 'iterate through letters in strings

        StrCmp = 0
        If Len(s1) <> Len(s2) Then
            StrCmp = 1
        Else
            For i = 1 To Len(s1)
                If Mid(s1, i, 1) <> Mid(s2, i, 1) Then
                    StrCmp = i
                    Exit Function
                End If
            Next i
        End If
    End Function

    Public Function ToGrid(text As String) As String
        'For 9 & 16 letter puzzles. organise them in a square grid. Insert crlf to wrap each line in a string to form square
        Dim i As Integer
        Dim sqrRoot As Integer = Math.Sqrt(Len(text))

        ToGrid = ""
        For i = 1 To Len(text)
            ToGrid += " " & text.Substring(i - 1, 1)
            If i Mod sqrRoot = 0 Then
                ToGrid += vbCrLf
            End If
        Next i
    End Function

End Module