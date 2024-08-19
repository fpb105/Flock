Public Class FormDebug
    Private Sub FormDebug_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
    End Sub

    Friend Sub AddMessage(message As String)
        'keep 25 lines
        Dim numOfLines As Integer = 25
        Dim lines = Me.TextBox1.Lines
        If (lines.Count > 25) Then
            Dim newLines = lines.Skip(1)
            Me.TextBox1.Lines = newLines.ToArray()
        End If

        TextBox1.Text += Environment.NewLine + message
    End Sub
End Class