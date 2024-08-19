Imports System.IO
Imports Microsoft.Web.WebView2.Core

Public Class FormHelp
    Private Sub FormHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        WebView21.EnsureCoreWebView2Async()
    End Sub

    Sub CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) _
        Handles WebView21.CoreWebView2InitializationCompleted

        Dim Text As String = File.ReadAllText("boid.htm")
        WebView21.CoreWebView2.NavigateToString(Text)
    End Sub

End Class