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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnagram))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusBar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Permut1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LstFound = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsCombine = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsGen9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsGen16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuToolsImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelpInstructions = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNewWord = New System.Windows.Forms.TextBox()
        Me.LstHuman = New System.Windows.Forms.ListBox()
        Me.CmListbox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CmTsMenuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtAnagram = New System.Windows.Forms.TextBox()
        Me.TxtFormatted = New System.Windows.Forms.RichTextBox()
        Me.TimeLimit = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.CmListbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBar1, Me.Permut1, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 403)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(411, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(0, 17)
        '
        'Permut1
        '
        Me.Permut1.Name = "Permut1"
        Me.Permut1.Size = New System.Drawing.Size(0, 25)
        Me.Permut1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 24)
        Me.ProgressBar1.ToolTipText = "Permutations"
        Me.ProgressBar1.Visible = False
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
        Me.Label2.Location = New System.Drawing.Point(12, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Words found"
        '
        'LstFound
        '
        Me.LstFound.BackColor = System.Drawing.SystemColors.Control
        Me.LstFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LstFound.FormattingEnabled = True
        Me.LstFound.ItemHeight = 15
        Me.LstFound.Location = New System.Drawing.Point(15, 103)
        Me.LstFound.Name = "LstFound"
        Me.LstFound.Size = New System.Drawing.Size(173, 259)
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
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFileExit})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "&File"
        '
        'MnuFileExit
        '
        Me.MnuFileExit.Name = "MnuFileExit"
        Me.MnuFileExit.Size = New System.Drawing.Size(93, 22)
        Me.MnuFileExit.Text = "E&xit"
        '
        'MnuTools
        '
        Me.MnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuToolsSearch, Me.MnuToolsCombine, Me.MnuToolsGen9, Me.MnuToolsGen16, Me.MnuToolsOptions, Me.MnuToolsImport})
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
        'MnuToolsImport
        '
        Me.MnuToolsImport.Name = "MnuToolsImport"
        Me.MnuToolsImport.Size = New System.Drawing.Size(136, 22)
        Me.MnuToolsImport.Text = "Import"
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
        Me.LstHuman.ContextMenuStrip = Me.CmListbox
        Me.LstHuman.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LstHuman.FormattingEnabled = True
        Me.LstHuman.ItemHeight = 15
        Me.LstHuman.Location = New System.Drawing.Point(217, 87)
        Me.LstHuman.Name = "LstHuman"
        Me.LstHuman.Size = New System.Drawing.Size(169, 274)
        Me.LstHuman.TabIndex = 18
        Me.LstHuman.TabStop = False
        '
        'CmListbox
        '
        Me.CmListbox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmTsMenuCopy})
        Me.CmListbox.Name = "CmListbox"
        Me.CmListbox.Size = New System.Drawing.Size(103, 26)
        '
        'CmTsMenuCopy
        '
        Me.CmTsMenuCopy.Name = "CmTsMenuCopy"
        Me.CmTsMenuCopy.Size = New System.Drawing.Size(102, 22)
        Me.CmTsMenuCopy.Text = "Copy"
        '
        'TxtAnagram
        '
        Me.TxtAnagram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAnagram.Location = New System.Drawing.Point(12, 49)
        Me.TxtAnagram.Name = "TxtAnagram"
        Me.TxtAnagram.Size = New System.Drawing.Size(173, 21)
        Me.TxtAnagram.TabIndex = 1
        '
        'TxtFormatted
        '
        Me.TxtFormatted.BackColor = System.Drawing.SystemColors.Control
        Me.TxtFormatted.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFormatted.Location = New System.Drawing.Point(217, 211)
        Me.TxtFormatted.Name = "TxtFormatted"
        Me.TxtFormatted.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.TxtFormatted.Size = New System.Drawing.Size(169, 150)
        Me.TxtFormatted.TabIndex = 19
        Me.TxtFormatted.Text = ""
        Me.TxtFormatted.Visible = False
        '
        'TimeLimit
        '
        Me.TimeLimit.Interval = 6000
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar2.Location = New System.Drawing.Point(0, 380)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(411, 23)
        Me.ProgressBar2.TabIndex = 20
        '
        'FrmAnagram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 425)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.TxtFormatted)
        Me.Controls.Add(Me.TxtAnagram)
        Me.Controls.Add(Me.LstHuman)
        Me.Controls.Add(Me.TxtNewWord)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LstFound)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmAnagram"
        Me.Text = "Anagram"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.CmListbox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LstFound As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Permut1 As ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As ToolStripProgressBar
    Friend WithEvents MnuTools As ToolStripMenuItem
    Friend WithEvents MnuToolsSearch As ToolStripMenuItem
    Friend WithEvents MnuToolsCombine As ToolStripMenuItem
    Friend WithEvents MnuToolsGen9 As ToolStripMenuItem
    Friend WithEvents MnuToolsOptions As ToolStripMenuItem
    Friend WithEvents MnuHelpInstructions As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNewWord As TextBox
    Friend WithEvents LstHuman As ListBox
    Friend WithEvents TxtAnagram As TextBox
    Friend WithEvents MnuToolsGen16 As ToolStripMenuItem
    Friend WithEvents TxtFormatted As RichTextBox
    Friend WithEvents TimeLimit As Timer
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents MnuToolsImport As ToolStripMenuItem
    Friend WithEvents CmListbox As ContextMenuStrip
    Friend WithEvents CmTsMenuCopy As ToolStripMenuItem
End Class
