Imports System.Windows.Forms

Public Class LocationDialog

    Public Percent As Integer
    Public type As String
    Public Speed As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Percent = NumericUpDown1.Value
        Speed = NumericUpDown2.Value
        If RadioButton1.Checked Then
            type = "h"
        Else
            type = "v"
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
