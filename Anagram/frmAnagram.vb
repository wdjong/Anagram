﻿Imports Anagram.My

Public Class FrmAnagram
    'Started 22/10/2001 (MSAccess)
    'Modified 18/8/2007-23/8/2007 (VS 2005 .NET 2)
    'Modified 26/9/2015 (VS 2012, .NET 4.5) Replaced MDB with SDF
    'Modified 25/10/2020 (VS 2019) added 9 letter word game, list of word version rather than find all permuation and check word dictionary
    'Requires installation of Microsoft Word Add ref to Microsoft Word Object Library
    'Also Required SQL Compact Edition (for SDF)

    Private Sub FrmAnagram_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed, MnuFileExit.Click
        Try
            StatusBar1.Text = "Closing... empty database"
            EmptyDatabase()
        Catch ex As Exception
            MsgBox("FrmAnagram_Closed: " & ex.Message)
        End Try
        End 'th-th-that's all folks
    End Sub

    Private Sub FrmAnagram_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lstHumanHeight = LstHuman.Height 'get original value to use when resizing
        aMSWord = CreateObject("Word.Application") 'use Word dictionary
        'Gen9LetterPuzzle()
        'MnuToolsGen9.Checked = True
        'TimeLimit.Start()
        'With ProgressBar2
        '    '.Visible = True
        '    .Minimum = 0
        '    .Maximum = My.Settings.TimeLimit
        '    .Value = 0
        'End With
    End Sub

    Private Sub LstHuman_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LstHuman.KeyPress
        If e.KeyChar = ChrW(Keys.Back) And LstHuman.SelectedItems.Count > 0 Then
            LstHuman.Items.Remove(LstHuman.SelectedItems.Item(0))
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub MnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuHelpAbout.Click
        'Help
        frmAbout.Show()
    End Sub

    Private Sub MnuHelpInstructions_Click(sender As Object, e As EventArgs) Handles MnuHelpInstructions.Click
        Try
            Dim AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory
            System.Diagnostics.Process.Start(AppPath + "AnagramHelp.html")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MnuToolsCombine_Click(sender As Object, e As EventArgs) Handles MnuToolsCombine.Click
        'see if we can use all the letters by combining words found (2 words only)
        If TxtAnagram.Text.Length > 0 And LstFound.Items.Count > 0 Then
            FindWordCombines(TxtAnagram.Text)
        Else
            MsgBox("Enter some letters in the 'text to rearrange' box and click on 'Tools Search' first. Then use combine.")
        End If
    End Sub

    Private Sub MnuToolsGen9_Click(sender As Object, e As EventArgs) Handles MnuToolsGen9.Click
        If MnuToolsGen9.Checked = True Then
            ProgressBar2.Visible = False
            TimeLimit.Stop()
            MnuToolsGen9.Checked = False
            LstFound.Visible = True
        Else
            Gen9LetterPuzzle()
            MnuToolsGen9.Checked = True
            TimeLimit.Start() 'see TimeLimit_Tick
            With ProgressBar2
                .Visible = True
                .Minimum = 0
                .Maximum = My.Settings.TimeLimit9 'This determine when times up
                .Value = 0
            End With
            LstFound.Visible = False
            LstFound.Items.Clear()
            LstHuman.Items.Clear()
            TxtNewWord.Text = ""
            TxtNewWord.Select()
            StatusBar1.Text = "Timing 9 letter word puzzle."
            DoAnagram()
        End If
    End Sub

    Private Sub MnuToolsGen16_Click(sender As Object, e As EventArgs) Handles MnuToolsGen16.Click
        If MnuToolsGen16.Checked = True Then
            ProgressBar2.Visible = False
            TimeLimit.Stop()
            MnuToolsGen16.Checked = False
            LstFound.Visible = True
        Else
            Gen16LetterPuzzle()
            MnuToolsGen16.Checked = True
            TimeLimit.Start() 'see TimeLimit_Tick
            With ProgressBar2
                .Visible = True
                .Minimum = 0
                .Maximum = My.Settings.TimeLimit16 'This determine when times up
                .Value = 0
            End With
            LstFound.Visible = False
            LstFound.Items.Clear()
            LstHuman.Items.Clear()
            TxtNewWord.Text = ""
            TxtNewWord.Select()
            StatusBar1.Text = "Timing 16 letter word puzzle."
            DoBogram()
        End If
    End Sub

    Private Sub MnuToolsImport_Click(sender As Object, e As EventArgs) Handles MnuToolsImport.Click
        PopulateWordList()
    End Sub

    Private Sub MnuToolsOptions_Click(sender As Object, e As EventArgs) Handles MnuToolsOptions.Click
        DlgOptions.ShowDialog()
    End Sub

    Private Sub MnuToolsSearch_Click(sender As Object, e As EventArgs) Handles MnuToolsSearch.Click
        'Search for words using letters in letter pool
        If TxtAnagram.Text.Length > 0 Then
            DoAnagram()
        Else
            MsgBox("You need to enter some letters in the 'text to rearrange' box or or choose the 'Generate 9' option from the Tools menu.")
        End If
    End Sub

    Private Sub TxtAnagram_TextChanged(sender As Object, e As EventArgs) Handles TxtAnagram.TextChanged
        Dim ft9 As Font = New Font("Lucida Sans Typewriter", 26)
        Dim ft16 As Font = New Font("Lucida Sans Typewriter", 24)
        Dim ftOther As Font = New Font("Lucida Sans Typewriter", 16)

        Select Case TxtAnagram.Text.Length
            Case 9
                TxtFormatted.Text = ToGrid(TxtAnagram.Text)
                TxtFormatted.Font = ft9
                TxtFormatted.Visible = True
                LstHuman.Height = lstHumanHeight - TxtFormatted.Height
                TxtFormatted.Select(10, 1)
                TxtFormatted.SelectionFont = New Font(TxtFormatted.Font.FontFamily, TxtFormatted.Font.Size, FontStyle.Bold)
            Case 16
                TxtFormatted.Text = ToGrid(TxtAnagram.Text)
                TxtFormatted.Font = ft16
                TxtFormatted.Visible = True
                LstHuman.Height = lstHumanHeight - TxtFormatted.Height
            Case Else
                TxtFormatted.Visible = False
                TxtFormatted.Font = ftOther
                LstHuman.Height = lstHumanHeight
        End Select

        'as you type in letters calculate the number of permutations
        'Permut1.Visible = True
        If Len(TxtAnagram.Text) > 12 Then
            Permut1.Text = ""
        Else
            Permut1.Text = CStr(Factorial(Len(TxtAnagram.Text))) & " permutations"
        End If
    End Sub

    Private Sub TxtNewWord_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNewWord.KeyPress
        Dim letterPool As String
        Dim aWord As String
        Dim minLen As Integer
        Dim maxLen As Integer
        Dim mustContain As String = ""
        Dim constraints As String = ""

        If e.KeyChar = vbCr Then
            letterPool = My.Forms.FrmAnagram.TxtAnagram.Text
            aWord = TxtNewWord.Text
            If My.Forms.FrmAnagram.MnuToolsGen9.Checked Then
                minLen = My.Settings.MinLen9
                maxLen = 9
                constraints = "Word length must be between " & minLen & " and " & maxLen
                If My.Settings.MustContain9 > 0 Then
                    mustContain = letterPool.Substring(My.Settings.MustContain9 - 1, 1)
                    constraints += " and must contain " & mustContain
                End If
            ElseIf My.Forms.FrmAnagram.MnuToolsGen16.Checked Then
                minLen = My.Settings.MinLen16
                maxLen = 16
                constraints = "Word length must be between " & minLen & " and " & maxLen & ". Letter must be adjacent and not re-used."
            Else
                minLen = 1
                maxLen = letterPool.Length
            End If
            If aWord.Length >= minLen And aWord.Length <= maxLen And (mustContain = "" Or aWord.Contains(mustContain)) Then
                If CheckLettersExist(letterPool, aWord) Then 'check if letters are present
                    If aMSWord.CheckSpelling(aWord) Then 'true means word thinks it's ok
                        If My.Forms.FrmAnagram.MnuToolsGen16.Checked Then
                            If CheckAdjacentNoOverlap(letterPool, aWord) Then
                                If Not My.Forms.FrmAnagram.LstHuman.Items.Contains(aWord) Then
                                    LstHuman.Items.Add(aWord)
                                    LstHuman.TopIndex = LstHuman.Items.Count - 1
                                    My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
                                    TxtNewWord.Text = ""
                                    e.Handled = True
                                    Exit Sub
                                End If
                            Else
                                MsgBox("Letters must be adjacent and not reused.")
                            End If
                        Else
                            If Not My.Forms.FrmAnagram.LstHuman.Items.Contains(aWord) Then
                                LstHuman.Items.Add(aWord)
                                LstHuman.TopIndex = LstHuman.Items.Count - 1
                                My.Forms.FrmAnagram.StatusBar1.Text = My.Forms.FrmAnagram.LstFound.Items.Count & " words found... (vs " & My.Forms.FrmAnagram.LstHuman.Items.Count & ")"
                                TxtNewWord.Text = ""
                                e.Handled = True
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("That is not a word we know.")
                    End If
                Else
                    MsgBox(aWord & " can't be made from " & letterPool)
                End If
            Else
                MsgBox(constraints)
            End If
        ElseIf TxtNewWord.Text = "" And e.KeyChar = vbBack Then
            If LstHuman.Items.Count > 0 Then
                TxtNewWord.Text = LstHuman.Items(LstHuman.Items.Count - 1)
                TxtNewWord.Select(TxtNewWord.Text.Length, 0)
                LstHuman.Items.RemoveAt(LstHuman.Items.Count - 1)
            End If
            e.Handled = True
            Exit Sub
        End If
    End Sub

    '------------------------
    Private Sub TimeLimit_Tick(sender As Object, e As EventArgs) Handles TimeLimit.Tick
        If ProgressBar2.Value + TimeLimit.Interval / 1000 < ProgressBar2.Maximum Then
            ProgressBar2.Value += TimeLimit.Interval / 1000
            Application.DoEvents()
        Else
            Beep()
            ProgressBar2.Value = ProgressBar2.Maximum
            TimeLimit.Stop()
            userBreak = True
            MsgBox("Time's up.")
            LstFound.Visible = True
            ProgressBar2.Visible = False
            Beep()
        End If
    End Sub

    Private Sub CmTsMenuCopy_Click(sender As Object, e As EventArgs) Handles CmTsMenuCopy.Click
        Dim data_object As New DataObject
        Dim copyString As String = ""
        For Each listItem As String In LstHuman.Items
            copyString += listItem.Trim() & vbCrLf
        Next
        data_object.SetData(DataFormats.Text, copyString)
        Clipboard.SetDataObject(data_object)
    End Sub
End Class
