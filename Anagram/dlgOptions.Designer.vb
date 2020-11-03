<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DlgOptions))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TxtMinLen9 = New System.Windows.Forms.TextBox()
        Me.LblMinLen9 = New System.Windows.Forms.Label()
        Me.LblNineLetter = New System.Windows.Forms.Label()
        Me.TxtTimeLimit9 = New System.Windows.Forms.TextBox()
        Me.LblTimeLimit9 = New System.Windows.Forms.Label()
        Me.LblTimeLimit16 = New System.Windows.Forms.Label()
        Me.TxtTimeLimit16 = New System.Windows.Forms.TextBox()
        Me.LblSixteenLetter = New System.Windows.Forms.Label()
        Me.TxtMinLen16 = New System.Windows.Forms.TextBox()
        Me.LblMinLen16 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TxtMinLen9
        '
        Me.TxtMinLen9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtMinLen9.Location = New System.Drawing.Point(110, 148)
        Me.TxtMinLen9.Name = "TxtMinLen9"
        Me.TxtMinLen9.Size = New System.Drawing.Size(100, 21)
        Me.TxtMinLen9.TabIndex = 8
        '
        'LblMinLen9
        '
        Me.LblMinLen9.AutoSize = True
        Me.LblMinLen9.Location = New System.Drawing.Point(12, 148)
        Me.LblMinLen9.Name = "LblMinLen9"
        Me.LblMinLen9.Size = New System.Drawing.Size(80, 13)
        Me.LblMinLen9.TabIndex = 9
        Me.LblMinLen9.Text = "Minimum length"
        '
        'LblNineLetter
        '
        Me.LblNineLetter.AutoSize = True
        Me.LblNineLetter.Location = New System.Drawing.Point(12, 95)
        Me.LblNineLetter.Name = "LblNineLetter"
        Me.LblNineLetter.Size = New System.Drawing.Size(84, 13)
        Me.LblNineLetter.TabIndex = 10
        Me.LblNineLetter.Text = "Nine letter game"
        '
        'TxtTimeLimit9
        '
        Me.TxtTimeLimit9.Location = New System.Drawing.Point(110, 122)
        Me.TxtTimeLimit9.Name = "TxtTimeLimit9"
        Me.TxtTimeLimit9.Size = New System.Drawing.Size(100, 20)
        Me.TxtTimeLimit9.TabIndex = 11
        '
        'LblTimeLimit9
        '
        Me.LblTimeLimit9.AutoSize = True
        Me.LblTimeLimit9.Location = New System.Drawing.Point(12, 122)
        Me.LblTimeLimit9.Name = "LblTimeLimit9"
        Me.LblTimeLimit9.Size = New System.Drawing.Size(50, 13)
        Me.LblTimeLimit9.TabIndex = 12
        Me.LblTimeLimit9.Text = "Time limit"
        '
        'LblTimeLimit16
        '
        Me.LblTimeLimit16.AutoSize = True
        Me.LblTimeLimit16.Location = New System.Drawing.Point(12, 209)
        Me.LblTimeLimit16.Name = "LblTimeLimit16"
        Me.LblTimeLimit16.Size = New System.Drawing.Size(50, 13)
        Me.LblTimeLimit16.TabIndex = 17
        Me.LblTimeLimit16.Text = "Time limit"
        '
        'TxtTimeLimit16
        '
        Me.TxtTimeLimit16.Location = New System.Drawing.Point(110, 209)
        Me.TxtTimeLimit16.Name = "TxtTimeLimit16"
        Me.TxtTimeLimit16.Size = New System.Drawing.Size(100, 20)
        Me.TxtTimeLimit16.TabIndex = 16
        '
        'LblSixteenLetter
        '
        Me.LblSixteenLetter.AutoSize = True
        Me.LblSixteenLetter.Location = New System.Drawing.Point(12, 182)
        Me.LblSixteenLetter.Name = "LblSixteenLetter"
        Me.LblSixteenLetter.Size = New System.Drawing.Size(97, 13)
        Me.LblSixteenLetter.TabIndex = 15
        Me.LblSixteenLetter.Text = "Sixteen letter game"
        '
        'TxtMinLen16
        '
        Me.TxtMinLen16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtMinLen16.Location = New System.Drawing.Point(110, 235)
        Me.TxtMinLen16.Name = "TxtMinLen16"
        Me.TxtMinLen16.Size = New System.Drawing.Size(100, 21)
        Me.TxtMinLen16.TabIndex = 13
        '
        'LblMinLen16
        '
        Me.LblMinLen16.AutoSize = True
        Me.LblMinLen16.Location = New System.Drawing.Point(12, 235)
        Me.LblMinLen16.Name = "LblMinLen16"
        Me.LblMinLen16.Size = New System.Drawing.Size(80, 13)
        Me.LblMinLen16.TabIndex = 14
        Me.LblMinLen16.Text = "Minimum length"
        '
        'DlgOptions
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.LblTimeLimit16)
        Me.Controls.Add(Me.TxtTimeLimit16)
        Me.Controls.Add(Me.LblSixteenLetter)
        Me.Controls.Add(Me.TxtMinLen16)
        Me.Controls.Add(Me.LblMinLen16)
        Me.Controls.Add(Me.LblTimeLimit9)
        Me.Controls.Add(Me.TxtTimeLimit9)
        Me.Controls.Add(Me.LblNineLetter)
        Me.Controls.Add(Me.TxtMinLen9)
        Me.Controls.Add(Me.LblMinLen9)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TxtMinLen9 As TextBox
    Friend WithEvents LblMinLen9 As Label
    Friend WithEvents LblNineLetter As Label
    Friend WithEvents TxtTimeLimit9 As TextBox
    Friend WithEvents LblTimeLimit9 As Label
    Friend WithEvents LblTimeLimit16 As Label
    Friend WithEvents TxtTimeLimit16 As TextBox
    Friend WithEvents LblSixteenLetter As Label
    Friend WithEvents TxtMinLen16 As TextBox
    Friend WithEvents LblMinLen16 As Label
End Class
