Module modUnusedCode
    'Public Sub Recombine(ByRef iLevel As Short, ByRef wordLen As Short)
    '    'Called from dostage1 and then recursively to get each combination of word
    '    Dim n As Short 'change the right n letters

    '    Try
    '        If iLevel > 1 And Not userBreak Then 'keep going deeper"
    '            For n = 1 To iLevel 'for each of the iLevel rightmost letters
    '                currWord = Left(currWord, wordLen - iLevel) & ShiftRight(Right(currWord, iLevel))
    '                Recombine(iLevel - 1, wordLen)
    '            Next n
    '        Else 'iLevel = 1
    '            My.Forms.FrmAnagram.ProgressBar1.Value += 1
    '            Dim SQL = "INSERT INTO tblCombination (combination) " _
    '            & "        SELECT '" & currWord & "' " _
    '            & "        WHERE NOT EXISTS (SELECT 1 FROM tblCombination WHERE combination = '" & currWord & "');"
    '            aCombCmd.CommandText = SQL
    '            aCombCmd.ExecuteNonQuery() 'add it to the tblCombine table"
    '            'If Not solutionFound And wordLen = 9 Then 'Check straight away for Nine-letter word 'Slows it all down too much
    '            '    If aMSWord.CheckSpelling(currWord) Then
    '            '        solutionFound = True
    '            '        If Not My.Forms.FrmAnagram.LstFound.Items.Contains(currWord) Then
    '            '            My.Forms.FrmAnagram.LstFound.Items.Add(currWord) 'Add it to list but don't add to database yet
    '            '            My.Forms.FrmAnagram.LstFound.TopIndex = My.Forms.FrmAnagram.LstFound.Items.Count - 1
    '            '        End If
    '            '    End If
    '            'End If
    '            System.Windows.Forms.Application.DoEvents() 'check for a break
    '        End If
    '    Catch ex As Exception
    '        MsgBox("recombine: " & ex.Message)
    '    End Try
    'End Sub

    'Public Sub DoStage1()
    '    'Called from doAnagram
    '    'Find all combinations and put them into tblCombination
    '    Dim n As Short 'each letter
    '    Dim wordLen As Short 'length of word

    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        solutionFound = False 'for 9 letter word search
    '        With My.Forms.FrmAnagram
    '            userBreak = False 'true if escape pressed
    '            .StatusBar1.Text = "Finding combinations"
    '            .ProgressBar1.Visible = True
    '            .ProgressBar1.Minimum = 0
    '            .ProgressBar1.Maximum = Factorial(Len(.TxtAnagram.Text))
    '            .ProgressBar1.Value = 0
    '            .MnuToolsSearch.Checked = True
    '            System.Windows.Forms.Application.DoEvents() 'check for a break

    '            currWord = .TxtAnagram.Text 'e.g. "tracehent"
    '            wordLen = Len(currWord)
    '            EmptyDatabase()
    '            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
    '                aCombCmd.Connection = aConnection
    '                aCombCmd.CommandType = CommandType.Text 'sql update command see below
    '                aConnection.Open()
    '                For n = 1 To wordLen 'for each letter in the word
    '                    currWord = ShiftRight(currWord) 'move the last letter to the beginning
    '                    Recombine(wordLen - 1, wordLen) 'in which words are added to tblCombine
    '                    If userBreak Then
    '                        Exit For
    '                    End If
    '                Next n
    '            End Using
    '            .ProgressBar1.Visible = False
    '            .StatusBar1.Text = "Stage 1 complete"
    '            System.Windows.Forms.Application.DoEvents() 'check for a break
    '        End With
    '        Cursor.Current = Cursors.Default
    '    Catch ex As Exception
    '        MsgBox("doStage1: " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub FillGrid(grid(,) As String, letterPool As String)
    '    Dim x As Integer = 1
    '    Dim y As Integer = 1
    '    For Each letter As String In letterPool
    '        grid(x, y) = letter
    '        x += 1
    '        If x > 4 Then
    '            x = 1
    '            y += 1
    '        End If
    '    Next
    'End Sub
    'Public Sub CheckForWords(ByRef aCombine As String, ByRef p As Short, ByVal wLen As Short, ByRef aResuCmd As SqlCeCommand)
    '    'Called from doStage2 (in which each record in tblCombination is iterated through
    '    Dim letterPool As String
    '    Dim i As Short 'i is theh length of determining each of the possible words to be tested
    '    Dim w As String 'each possible Word
    '    Dim start As Short 'the shortest length of the string to check as a possible word
    '    Dim minLen As Short 'the minimum length of a word
    '    Dim mustContain As String = ""

    '    letterPool = My.Forms.FrmAnagram.TxtAnagram.Text
    '    If My.Forms.FrmAnagram.MnuToolsGen9.Checked Then
    '        minLen = My.Settings.MinLen9
    '        mustContain = letterPool.Substring(4)
    '    ElseIf My.Forms.FrmAnagram.MnuToolsGen9.Checked Then
    '        minLen = My.Settings.MinLen16
    '    Else
    '        minLen = 1
    '    End If

    '    Try
    '        My.Forms.FrmAnagram.LstFound.Items.Clear()
    '        minLen = My.Settings.MinLen9 'Val(My.Forms.FrmAnagram.TxtMinLen.Text)
    '        If p > minLen Then start = p Else start = minLen 'work out where to start looking
    '        For i = start To wLen 'look at possible words from the shortest not already checked to the longest possible
    '            w = Left(aCombine, i) 'w is a possible word
    '            If InStr(w, mustContain) Then 'contains obligatory centreLetter
    '                'My.Forms.FrmAnagram.TxtAnagram.Text = w 'display the combination being checked
    '                If aMSWord.CheckSpelling(w) Then 'true means word thinks it's ok
    '                    If Not My.Forms.FrmAnagram.LstFound.Items.Contains(w) Then
    '                        My.Forms.FrmAnagram.LstFound.Items.Add(w)
    '                        My.Forms.FrmAnagram.LstFound.TopIndex = My.Forms.FrmAnagram.LstFound.Items.Count - 1
    '                        My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
    '                        '.ProgressBar1.Value += 1
    '                        aResuCmd.CommandText = "INSERT INTO tblResult ( result ) VALUES('" & w & "');" ' WHERE NOT EXISTS (SELECT result FROM tblResult WHERE result = '" & w & "');"
    '                        aResuCmd.ExecuteNonQuery() 'add it to the tblCombine table"
    '                    End If
    '                End If
    '            End If
    '            System.Windows.Forms.Application.DoEvents() 'check for a break
    '        Next i
    '    Catch ex As Exception
    '        MsgBox("checkforWords: " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub DebugPrintUsed(used() As String)
    '    Dim c As String
    '    For y = 0 To 3
    '        For x = 0 To 3
    '            If used(y * 4 + x) = "" Then c = "." Else c = used(y * 4 + x)
    '            Debug.Write(c)
    '        Next
    '        Debug.WriteLine("")
    '    Next
    '    Debug.WriteLine("----")
    '    Debug.WriteLine("")
    'End Sub

    'Public Sub DisplayCombines()
    '    'Called from CmdCombine_Click
    '    'Fills a Textbox with all records in tblCombine
    '    Dim aCombineCommand As New SqlCeCommand
    '    Dim aCombineDR As SqlCeDataReader
    '    Dim aTextBox = My.Forms.FrmAnagram.TxtAnagram

    '    Try
    '        My.Forms.FrmAnagram.LstFound.Items.Clear()
    '        Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
    '            aCombineCommand.Connection = aConnection
    '            aCombineCommand.CommandType = CommandType.Text 'sql update command see below
    '            aCombineCommand.CommandText = "SELECT DISTINCT combine FROM tblCombine"
    '            aConnection.Open()
    '            aCombineDR = aCombineCommand.ExecuteReader
    '            Do While aCombineDR.Read()
    '                My.Forms.FrmAnagram.LstFound.Items.Add(aCombineDR("combine").ToString)
    '            Loop
    '        End Using
    '    Catch ex As Exception
    '        MsgBox("displayCombines: " & ex.Message)
    '    End Try
    'End Sub
    'Public Sub DoStage2()
    '    'Called from doAnagram
    '    'Find all words in tblCombination strings and add them to tblResult
    '    Dim wLen As Short 'because TxtAnagram is modified during checkForWords this must be calculated here
    '    Dim pDiff As Short 'the point of diffence from the previous word (to avoid rechecking sequences)
    '    Dim prevWord As String 'in order to avoid rechecking
    '    Dim thisWord As String 'in order to avoid rechecking
    '    Dim aResuCmd As New SqlCeCommand 'used in stage2 for inserting commands
    '    Dim aCmbiCmd As New SqlCeCommand 'for interating through combinations
    '    Dim aCmbiDR As SqlCeDataReader 'for iterating through combinations
    '    Try
    '        With My.Forms.FrmAnagram
    '            wLen = Len(My.Forms.FrmAnagram.TxtAnagram.Text) 'the length of the original anagram string
    '            Cursor.Current = Cursors.WaitCursor
    '            .StatusBar1.Text = .LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
    '            .LstFound.Items.Clear()
    '            '.ProgressBar1.Visible = True
    '            '.ProgressBar1.Value = 0
    '            '.ProgressBar1.Maximum = Val(.Permut1.Text) 'approximately
    '            System.Windows.Forms.Application.DoEvents() 'check for a break
    '            prevWord = ""
    '            Using aConnection As New SqlCeConnection(My.Settings.AnagramConnectionString)
    '                aCmbiCmd.Connection = aConnection
    '                aCmbiCmd.CommandType = CommandType.Text 'populate data reader
    '                aResuCmd.Connection = aConnection
    '                aResuCmd.CommandType = CommandType.Text
    '                aConnection.Open()
    '                aCmbiCmd.CommandText = "SELECT combination FROM tblCombination order by combination" 'source
    '                aCmbiDR = aCmbiCmd.ExecuteReader
    '                While aCmbiDR.Read And Not userBreak
    '                    thisWord = aCmbiDR("combination").ToString
    '                    pDiff = StrCmp(thisWord, prevWord) 'determines where we start checking for words
    '                    CheckForWords(thisWord, pDiff, wLen, aResuCmd)
    '                    prevWord = thisWord
    '                End While
    '            End Using
    '            .StatusBar1.Text = .LstFound.Items.Count & " words found (finished) (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
    '            '.ProgressBar1.Visible = False
    '            Cursor.Current = Cursors.Default 'mousepointer
    '        End With

    '    Catch ex As Exception
    '        MsgBox("doStage2: " & ex.Message)
    '    End Try
    'End Sub


End Module
