Option Strict Off
Option Explicit On

Imports System.Data.SqlServerCe
Imports Microsoft.Office.Interop

Module modAnagram
    Dim aMSWord As Word.Application 'Microsoft Word
    Dim currWord As String 'used in recursive recombine: current arrangement of letters
    Public txtAnagramTextOnly As String 'Text is formatted in text box to suit game

    ReadOnly aCombCmd As New SqlCeCommand
    'used in recursive recombine so that's why it's declared out here
    Public userBreak As Boolean 'CmdSearch during the searching says 'stop' and clicking on it interrupts the search
    Public Const aSearchButtonStr As String = "Search for words"

    Sub DoAnagram()
        'This is the beginning of the main search routine
        'Called from FrmAnagram CmdSearch.click event
        Try
            'tblCombination contains a record for each combination of all letters
            DoStage1() 'find all combinations and put them into tblCombination
            DoStage2() 'find words and put them into tblResult
        Catch ex As Exception
            MsgBox("doAnagram: " & ex.Message)
        End Try
    End Sub

    Sub DoStage1()
        'Called from doAnagram
        'Find all combinations and put them into tblCombination
        Dim n As Short 'each letter
        Dim wordLen As Short 'length of word

        Try
            My.Forms.FrmAnagram.StatusBar1.Text = "Stage 1... Find all combinations of letters"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            userBreak = False 'true if escape pressed
            currWord = My.Forms.FrmAnagram.TxtAnagram.Text 'e.g. "tracehent"
            wordLen = Len(currWord)
            With My.Forms.FrmAnagram.ProgressBar1
                .Visible = True
                .Minimum = 0
                .Maximum = Val(My.Forms.FrmAnagram.Permut1.Text)
                .Value = 0
            End With
            My.Forms.FrmAnagram.LstFound.Items.Clear()
            EmptyDatabase()
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aCombCmd.Connection = aConnection
                aCombCmd.CommandType = CommandType.Text 'sql update command see below
                aConnection.Open()
                For n = 1 To wordLen 'for each letter in the word
                    currWord = ShiftRight(currWord) 'move the last letter to the beginning
                    Recombine(wordLen - 1, wordLen) 'in which words are added to tblCombine
                    System.Windows.Forms.Application.DoEvents() 'check for a break
                Next n
            End Using
            My.Forms.FrmAnagram.ProgressBar1.Visible = False
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            My.Forms.FrmAnagram.StatusBar1.Text = "Stage 1 complete"
        Catch ex As Exception
            MsgBox("doStage1: " & ex.Message)
        End Try
    End Sub

    Sub Recombine(ByRef iLevel As Short, ByRef wordLen As Short)
        'Called from dostage1 and then recursively to get each combination of word
        'currword "abc" recombine 2, 3 
        'currword=a cb recombine 1, 3 addToDB "a cb"
        'currword=a bc recombine 1, 3 addToDB "a bc"
        Dim n As Short 'change the right n letters

        Try
            If iLevel > 1 And Not userBreak Then 'keep going deeper"
                For n = 1 To iLevel 'for each of the iLevel rightmost letters
                    currWord = Left(currWord, wordLen - iLevel) & ShiftRight(Right(currWord, iLevel))
                    Recombine(iLevel - 1, wordLen)
                    Application.DoEvents()
                Next n
            Else 'iLevel = 1
                My.Forms.FrmAnagram.ProgressBar1.Value = My.Forms.FrmAnagram.ProgressBar1.Value + 1
                Dim SQL = "INSERT INTO tblCombination (combination) " _
                & "        SELECT '" & currWord & "' " _
                & "        WHERE NOT EXISTS (SELECT 1 FROM tblCombination WHERE combination = '" & currWord & "');"
                aCombCmd.CommandText = SQL
                'aCombCmd.CommandText = "INSERT INTO tblCombination ( combination ) VALUES('" & currWord & "');"
                aCombCmd.ExecuteNonQuery() 'add it to the tblCombine table"
                'Application.DoEvents()
                'My.Forms.FrmAnagram.TxtAnagram.Text = currWord
            End If
        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'ignore error relating to inserting duplicates
                MsgBox("recombine: " & ex.Message)
            Else
                Debug.Print("Duplicate: ")
            End If
        End Try
    End Sub

    Function ShiftRight(ByVal a As String) As String
        'Called by recombine
        'move all the letters of the 'word' right
        'move the last letter to the start of the 'word'
        ShiftRight = Right(a, 1) & Left(a, Len(a) - 1)
    End Function

    Sub DoStage2()
        'Called from doAnagram
        'Find all words in tblCombination strings and add them to tblResult
        Dim wLen As Short 'because TxtAnagram is modified during checkForWords this must be calculated here
        Dim pDiff As Short 'the point of diffence from the previous word (to avoid rechecking sequences)
        Dim prevWord As String 'in order to avoid rechecking
        Dim thisWord As String 'in order to avoid rechecking
        Dim aResuCmd As New SqlCeCommand 'used in stage2 for inserting commands
        Dim aCmbiCmd As New SqlCeCommand 'for interating through combinations
        Dim aCmbiDR As SqlCeDataReader 'for iterating through combinations
        Try
            My.Forms.FrmAnagram.StatusBar1.Text = "Stage 2: Checking list for words"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            aMSWord = CreateObject("Word.Application") 'use Word dictionary
            wLen = Len(My.Forms.FrmAnagram.TxtAnagram.Text) 'the length of the original anagram string
            My.Forms.FrmAnagram.ProgressBar1.Visible = True
            My.Forms.FrmAnagram.ProgressBar1.Value = 0
            My.Forms.FrmAnagram.ProgressBar1.Maximum = Val(My.Forms.FrmAnagram.Permut1.Text) 'approximately
            prevWord = ""
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aCmbiCmd.Connection = aConnection
                aCmbiCmd.CommandType = CommandType.Text 'populate data reader
                aResuCmd.Connection = aConnection
                aResuCmd.CommandType = CommandType.Text
                aConnection.Open()
                aCmbiCmd.CommandText = "SELECT combination FROM tblCombination order by combination" 'source
                aCmbiDR = aCmbiCmd.ExecuteReader
                While aCmbiDR.Read And Not userBreak
                    thisWord = aCmbiDR("combination").ToString
                    pDiff = StrCmp(thisWord, prevWord) 'determines where we start checking for words
                    CheckForWords(thisWord, pDiff, wLen, aResuCmd)
                    prevWord = thisWord
                    My.Forms.FrmAnagram.ProgressBar1.Value = My.Forms.FrmAnagram.ProgressBar1.Value + 1
                    System.Windows.Forms.Application.DoEvents()
                End While
            End Using
            aMSWord = Nothing
            My.Forms.FrmAnagram.StatusBar1.Text = "Stage 2: Complete"
            My.Forms.FrmAnagram.ProgressBar1.Visible = False
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'mousepointer
        Catch ex As Exception
            MsgBox("doStage2: " & ex.Message)
        End Try
    End Sub

    Sub CheckForWords(ByRef aCombine As String, ByRef p As Short, ByVal wLen As Short, ByRef aResuCmd As SqlCeCommand)
        'Called from doStage2 (in which each record in tblCombination is iterated through
        Dim i As Short 'i is theh length of determining each of the possible words to be tested
        Dim w As String 'each possible Word
        Dim start As Short 'the shortest length of the string to check as a possible word
        Dim minLen As Short 'the minimum length of a word
        'either the first point of difference from the previous combination 
        'or the minimum length, which ever is greater

        Try
            minLen = Val(My.Forms.FrmAnagram.TxtMinLen.Text)
            If p > minLen Then start = p Else start = minLen 'work out where to start looking
            For i = start To wLen 'look at possible words from the shortest not already checked to the longest possible
                w = Left(aCombine, i) 'w is a possible word
                If InStr(w, My.Forms.FrmAnagram.TxtLetter.Text) Then 'contains obligatory centreLetter
                    My.Forms.FrmAnagram.TxtAnagram.Text = w 'display the combination being checked
                    If aMSWord.CheckSpelling(w) Then 'true means word thinks it's ok
                        My.Forms.FrmAnagram.LstFound.Items.Add(w)
                        My.Forms.FrmAnagram.LstFound.TopIndex = My.Forms.FrmAnagram.LstFound.Items.Count - 1
                        aResuCmd.CommandText = "INSERT INTO tblResult ( result ) VALUES('" & w & "');"
                        aResuCmd.ExecuteNonQuery() 'add it to the tblCombine table"
                    End If
                End If
            Next i
        Catch ex As Exception
            MsgBox("checkforWords: " & ex.Message)
        End Try
    End Sub

    Sub DisplayCombines()
        'Called from CmdCombine_Click
        'Fills a Textbox with all records in tblCombine
        Dim aCombineCommand As New SqlCeCommand
        Dim aCombineDR As SqlCeDataReader
        Dim aTextBox = My.Forms.FrmAnagram.TxtAnagram

        Try
            My.Forms.FrmAnagram.LstFound.Items.Clear()
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aCombineCommand.Connection = aConnection
                aCombineCommand.CommandType = CommandType.Text 'sql update command see below
                aCombineCommand.CommandText = "SELECT DISTINCT combine FROM tblCombine"
                aConnection.Open()
                aCombineDR = aCombineCommand.ExecuteReader
                Do While aCombineDR.Read()
                    My.Forms.FrmAnagram.LstFound.Items.Add(aCombineDR("combine").ToString)
                Loop
            End Using
        Catch ex As Exception
            MsgBox("displayCombines: " & ex.Message)
        End Try
    End Sub

    Sub EmptyDatabase()
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

    Function Factorial(ByRef n As Integer) As Integer
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

    Sub FindWordCombines(ByRef s As String)
        'ADO.NET version
        'Try each combination of words to see if all letters can be used
        's (from TxtAnagram) are all the letters to rearrange
        ' Assumes connectionString is a valid connection string.
        Dim aResultCommand As New SqlCeCommand
        Dim aResultDR As SqlCeDataReader
        Dim aCombineCommand As New SqlCeCommand
        Dim aResultWord As String
        Dim s1 As String

        Try
            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
                aCombineCommand.Connection = aConnection
                aCombineCommand.CommandType = CommandType.Text 'sql update command see below
                aResultCommand.Connection = aConnection
                aResultCommand.CommandText = "tblResult"
                aResultCommand.CommandType = CommandType.TableDirect
                aConnection.Open()
                aResultDR = aResultCommand.ExecuteReader
                Do While aResultDR.Read()
                    aResultWord = aResultDR("Result").ToString
                    s1 = FindWord(s, aResultWord) 'combine it with all others to find 2 words that use all letters
                    If s1 <> "" Then 'if a combination of 2 words is found
                        aCombineCommand.CommandText = "INSERT INTO tblCombine ( combine ) VALUES('" & s1 & "');"
                        aCombineCommand.ExecuteNonQuery() 'add it to the tblCombine table"
                        'System.Diagnostics.Debug.WriteLine(s1)
                    End If
                Loop
            End Using

        Catch ex As Exception
            MsgBox("FindWordCombines: " & ex.Message)
        End Try

    End Sub

    Function FindWord(ByRef s As String, ByRef s1 As String) As String
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

    Function Anagram(ByRef s1 As String, ByRef s2 As String) As Boolean
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
            End If
        Next i
    End Function

    Function StrCmp(ByRef s1 As String, ByRef s2 As String) As Short
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

    Public Sub Gen9LetterPuzzle()
        'http://www.yougowords.com/9-letters-12
        Randomize()
        Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim text = IO.File.ReadAllText(AppPath + "nineletterwords.csv")
        Dim words = text.Split(vbCr) 'note: leaves vbLF at start of each line
        Dim value As Integer = CInt(Int((words.Length * Rnd()) + 1))
        My.Forms.FrmAnagram.TxtAnagram.Text = MixUpWord(words(value))
        My.Forms.FrmAnagram.TxtLetter.Text = My.Forms.FrmAnagram.TxtAnagram.Text.Substring(4, 1)
        My.Forms.FrmAnagram.TxtMinLen.Text = 4
    End Sub

    Private Function MixUpWord(v As String) As String
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
                Debug.Print(v)
            End If
        Next
        MixUpWord = v
    End Function

End Module