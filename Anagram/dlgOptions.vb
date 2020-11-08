Imports System.Windows.Forms

Public Class DlgOptions

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.MinLen9 = Val(TxtMinLen9.Text)
        My.Settings.TimeLimit9 = Val(TxtTimeLimit9.Text)
        My.Settings.MinLen16 = Val(TxtMinLen16.Text)
        My.Settings.TimeLimit16 = Val(TxtTimeLimit16.Text)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtMinLen9.Text = My.Settings.MinLen9.ToString
        TxtTimeLimit9.Text = My.Settings.TimeLimit9.ToString
        TxtMinLen16.Text = My.Settings.MinLen16.ToString
        TxtTimeLimit16.Text = My.Settings.TimeLimit16.ToString
    End Sub

End Class
