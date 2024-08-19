Imports System.Reflection

Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim applicationTitle As String = Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyTitleAttribute)()?.Title

        If String.IsNullOrEmpty(applicationTitle) Then
            applicationTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().GetName().Name)
        End If

        Me.Text = String.Format("About {0}", applicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = If(Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyProductAttribute)()?.Product, "")
        Me.LabelVersion.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version)
        Me.LabelCopyright.Text = If(Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyCopyrightAttribute)()?.Copyright, "")
        Me.LabelCompanyName.Text = If(Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyCompanyAttribute)()?.Company, "")
        Me.TextBoxDescription.Text = If(Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyDescriptionAttribute)()?.Description, "")

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
