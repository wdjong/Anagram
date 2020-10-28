<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAnagram
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusBar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Permut1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Timer1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMinLen = New System.Windows.Forms.TextBox()
        Me.LstFound = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsCombine = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsGen9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsGen16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelpInstructions = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtLetter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNewWord = New System.Windows.Forms.TextBox()
        Me.LstHuman = New System.Windows.Forms.ListBox()
        Me.TxtAnagram = New System.Windows.Forms.TextBox()
        Me.TxtFormatted = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBar1, Me.Permut1, Me.ProgressBar1, Me.Timer1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 373)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(411, 30)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(62, 25)
        Me.StatusBar1.Text = "StatusBar1"
        '
        'Permut1
        '
        Me.Permut1.Name = "Permut1"
        Me.Permut1.Size = New System.Drawing.Size(52, 25)
        Me.Permut1.Text = "Permut1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 24)
        '
        'Timer1
        '
        Me.Timer1.Name = "Timer1"
        Me.Timer1.Size = New System.Drawing.Size(100, 24)
        Me.Timer1.ToolTipText = "Time remaining"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Letters to rearrange"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Words found"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Minimum length"
        '
        'TxtMinLen
        '
        Me.TxtMinLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtMinLen.Location = New System.Drawing.Point(124, 103)
        Me.TxtMinLen.Name = "TxtMinLen"
        Me.TxtMinLen.Size = New System.Drawing.Size(61, 21)
        Me.TxtMinLen.TabIndex = 4
        '
        'LstFound
        '
        Me.LstFound.BackColor = System.Drawing.SystemColors.Control
        Me.LstFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LstFound.FormattingEnabled = True
        Me.LstFound.ItemHeight = 15
        Me.LstFound.Location = New System.Drawing.Point(15, 162)
        Me.LstFound.Name = "LstFound"
        Me.LstFound.Size = New System.Drawing.Size(173, 199)
        Me.LstFound.TabIndex = 14
        Me.LstFound.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile, Me.MnuTools, Me.MnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(411, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'MnuTools
        '
        Me.MnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuToolsSearch, Me.MnuToolsCombine, Me.MnuToolsGen9, Me.MnuToolsGen16, Me.MnuToolsOptions})
        Me.MnuTools.Name = "MnuTools"
        Me.MnuTools.Size = New System.Drawing.Size(46, 20)
        Me.MnuTools.Text = "&Tools"
        '
        'MnuToolsSearch
        '
        Me.MnuToolsSearch.Name = "MnuToolsSearch"
        Me.MnuToolsSearch.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsSearch.Text = "&Search"
        '
        'MnuToolsCombine
        '
        Me.MnuToolsCombine.Name = "MnuToolsCombine"
        Me.MnuToolsCombine.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsCombine.Text = "&Combine"
        '
        'MnuToolsGen9
        '
        Me.MnuToolsGen9.Name = "MnuToolsGen9"
        Me.MnuToolsGen9.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsGen9.Text = "&Generate 9"
        '
        'MnuToolsGen16
        '
        Me.MnuToolsGen16.Name = "MnuToolsGen16"
        Me.MnuToolsGen16.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsGen16.Text = "Generate 16"
        '
        'MnuToolsOptions
        '
        Me.MnuToolsOptions.Name = "MnuToolsOptions"
        Me.MnuToolsOptions.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsOptions.Text = "&Options"
        '
        'MnuHelp
        '
        Me.MnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuHelpAbout, Me.MnuHelpInstructions})
        Me.MnuHelp.Name = "MnuHelp"
        Me.MnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.MnuHelp.Text = "&Help"
        '
        'MnuHelpAbout
        '
        Me.MnuHelpAbout.Name = "MnuHelpAbout"
        Me.MnuHelpAbout.Size = New System.Drawing.Size(136, 22)
        Me.MnuHelpAbout.Text = "&About"
        '
        'MnuHelpInstructions
        '
        Me.MnuHelpInstructions.Name = "MnuHelpInstructions"
        Me.MnuHelpInstructions.Size = New System.Drawing.Size(136, 22)
        Me.MnuHelpInstructions.Text = "&Instructions"
        '
        'TxtLetter
        '
        Me.TxtLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtLetter.Location = New System.Drawing.Point(12, 103)
        Me.TxtLetter.Name = "TxtLetter"
        Me.TxtLetter.Size = New System.Drawing.Size(61, 21)
        Me.TxtLetter.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Must contain"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Your words"
        '
        'TxtNewWord
        '
        Me.TxtNewWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtNewWord.Location = New System.Drawing.Point(217, 49)
        Me.TxtNewWord.Name = "TxtNewWord"
        Me.TxtNewWord.Size = New System.Drawing.Size(169, 21)
        Me.TxtNewWord.TabIndex = 2
        '
        'LstHuman
        '
        Me.LstHuman.BackColor = System.Drawing.SystemColors.Control
        Me.LstHuman.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LstHuman.FormattingEnabled = True
        Me.LstHuman.ItemHeight = 15
        Me.LstHuman.Location = New System.Drawing.Point(217, 87)
        Me.LstHuman.Name = "LstHuman"
        Me.LstHuman.Size = New System.Drawing.Size(169, 274)
        Me.LstHuman.TabIndex = 18
        Me.LstHuman.TabStop = False
        '
        'TxtAnagram
        '
        Me.TxtAnagram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAnagram.Location = New System.Drawing.Point(12, 49)
        Me.TxtAnagram.Name = "TxtAnagram"
        Me.TxtAnagram.Size = New System.Drawing.Size(173, 21)
        Me.TxtAnagram.TabIndex = 1
        Me.TxtAnagram.Text = "ragasmany"
        '
        'TxtFormatted
        '
        Me.TxtFormatted.Location = New System.Drawing.Point(232, 231)
        Me.TxtFormatted.Name = "TxtFormatted"
        Me.TxtFormatted.Size = New System.Drawing.Size(139, 130)
        Me.TxtFormatted.TabIndex = 19
        Me.TxtFormatted.Text = ""
        '
        'FrmAnagram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 403)
        Me.Controls.Add(Me.TxtFormatted)
        Me.Controls.Add(Me.TxtAnagram)
        Me.Controls.Add(Me.LstHuman)
        Me.Controls.Add(Me.TxtNewWord)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LstFound)
        Me.Controls.Add(Me.TxtMinLen)
        Me.Controls.Add(Me.TxtLetter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmAnagram"
        Me.Text = "Anagram"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMinLen As System.Windows.Forms.TextBox
    Friend WithEvents LstFound As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Permut1 As ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As ToolStripProgressBar
    Friend WithEvents MnuTools As ToolStripMenuItem
    Friend WithEvents MnuToolsSearch As ToolStripMenuItem
    Friend WithEvents MnuToolsCombine As ToolStripMenuItem
    Friend WithEvents Timer1 As ToolStripProgressBar
    Friend WithEvents MnuToolsGen9 As ToolStripMenuItem
    Friend WithEvents MnuToolsOptions As ToolStripMenuItem
    Friend WithEvents MnuHelpInstructions As ToolStripMenuItem
    Friend WithEvents TxtLetter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNewWord As TextBox
    Friend WithEvents LstHuman As ListBox
    Friend WithEvents TxtAnagram As TextBox
    Friend WithEvents MnuToolsGen16 As ToolStripMenuItem
    Friend WithEvents TxtFormatted As RichTextBox
End Class
