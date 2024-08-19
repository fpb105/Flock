Imports System.Reflection

Public NotInheritable Class SplashScreen1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        Dim appTitle As String = Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyTitleAttribute)()?.Title

        If String.IsNullOrEmpty(appTitle) Then
            appTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().GetName().Name)
        End If

        ApplicationTitle.Text = appTitle

        Dim versionValue = Assembly.GetExecutingAssembly().GetName().Version

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, versionValue.Major, versionValue.Minor, versionValue.Build, versionValue.Revision)

        Version.Text = System.String.Format(Version.Text, versionValue.Major, versionValue.Minor)

        'Copyright info
        Copyright.Text = If(Assembly.GetExecutingAssembly().GetCustomAttribute(Of AssemblyCopyrightAttribute)()?.Copyright, "")
    End Sub

End Class
