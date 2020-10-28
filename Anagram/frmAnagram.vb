Public Class FrmAnagram
    'Started 22/10/2001 (Access?)
    'Modified 18/8/2007-23/8/2007 (VS 2005 .NET 2)
    'Modified 26/9/2015 (VS 2012, .NET 4.5) Replaced MDB with SDF
    'Modified 25/10/2020 (VS 2019)
    'Requires installation of Microsoft Word Add ref to Microsoft Word Object Library
    'Also Required SQL Compact Edition (for SDF)

    Private Sub FrmAnagram_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Gen9LetterPuzzle()
    End Sub

    Private Sub TxtAnagram_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtAnagram.TextChanged
        'as you type in letters calculate the number of permutations
        StatusBar1.Text = "When you're ready press the Search button"
        If Len(TxtAnagram.Text) > 12 Then
            Permut1.Text = CStr(1)
        Else
            Permut1.Text = CStr(Factorial(Len(TxtAnagram.Text)))
        End If
    End Sub

    Private Sub FrmAnagram_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed, ExitToolStripMenuItem.Click
        Try
            StatusBar1.Text = "Closing... empty database"
            EmptyDatabase()
        Catch ex As Exception
            MsgBox("FrmAnagram_Closed: " & ex.Message)
        End Try
        End 'th-th-that's all folks
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuHelpAbout.Click
        'Help
        frmAbout.Show()
    End Sub

    Private Sub MnuToolsSearch_Click(sender As Object, e As EventArgs) Handles MnuToolsSearch.Click
        'Search all combinations of the letters for valid words
        StatusBar1.Text = "Searching. (Tools | Search to stop)"
        If MnuToolsSearch.Checked Then
            userBreak = True
        Else
            MnuToolsSearch.Checked = True
            DoAnagram()
        End If
    End Sub

    Private Sub MnuToolsCombine_Click(sender As Object, e As EventArgs) Handles MnuToolsCombine.Click
        'see if we can use all the letters by combining words found (2 words only)
        FindWordCombines(TxtAnagram.Text)
        DisplayCombines()
    End Sub

    Private Sub txtAnagram_TextChanged_1(sender As Object, e As EventArgs) Handles TxtAnagram.TextChanged
        Dim ft9 As Font = New Font("Lucida Sans Typewriter", 24)
        Dim ft16 As Font = New Font("Lucida Sans Typewriter", 18)
        Dim ftOther As Font = New Font("Lucida Sans Typewriter", 16)

        Select Case TxtAnagram.Text.Length = 9
            Case 9
                TxtFormatted.Text = ToGrid(TxtAnagram.Text)
                TxtFormatted.Font = ft9
                TxtFormatted.Visible = True
                LstHuman.Height = 268 - TxtFormatted.Height
                TxtFormatted.Select(9, 1)
                TxtFormatted.SelectionFont = New Font(TxtFormatted.Font.FontFamily, TxtFormatted.Font.Size, FontStyle.Bold)
            Case 16
                TxtFormatted.Text = TxtAnagram.Text.Substring(0, 4) & vbNewLine _
                    & TxtAnagram.Text.Substring(4, 4) & vbNewLine _
                    & TxtAnagram.Text.Substring(8, 4) & vbNewLine _
                    & TxtAnagram.Text.Substring(12, 4) & vbNewLine
                LstHuman.Height = 268 - TxtFormatted.Height
                TxtFormatted.Font = ft16
                TxtFormatted.Visible = True
            Case Else
                TxtFormatted.Visible = False
                TxtFormatted.Font = ftOther
                LstHuman.Height = 268
        End Select

    End Sub

    Private Function ToGrid(text As String) As String
        Dim i As Integer
        ToGrid = ""
        For i = 1 To Len(text)
            ToGrid += text.Substring(i - 1, 1) & " "
            If i Mod 3 = 0 Then
                ToGrid += vbCrLf
            End If
        Next i
    End Function

    Private Sub TxtNewWord_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNewWord.KeyPress
        If e.KeyChar = vbCr Then
            LstHuman.Items.Add(TxtNewWord.Text)
            TxtNewWord.Text = ""
            e.Handled = True
            Exit Sub
        ElseIf TxtNewWord.Text = "" And e.KeyChar = vbBack Then
            TxtNewWord.Text = LstHuman.Items(LstHuman.Items.Count - 1)
            TxtNewWord.Select(TxtNewWord.Text.Length, 0)
            LstHuman.Items.RemoveAt(LstHuman.Items.Count - 1)
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub MnuHelpInstructions_Click(sender As Object, e As EventArgs) Handles MnuHelpInstructions.Click
        Try
            Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
            System.Diagnostics.Process.Start(AppPath + "AnagramHelp.html")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MnuToolsGen9_Click(sender As Object, e As EventArgs) Handles MnuToolsGen9.Click
        Gen9LetterPuzzle()
    End Sub
End Class
