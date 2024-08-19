Imports System.IO
Imports Newtonsoft.Json

Public Class Form1

#Region "Local variables"
    Dim CurrentMousePosition As Point
    Public Property LeaderBoid As Boid
    Public Property BoidList As New List(Of Boid)
    Public Property ObstacleList As New List(Of Obstacle)

    Shared Count As Integer = 0
    Dim FormDebug As New FormDebug()
#End Region

#Region "Form events"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LeaderBoid = New Boid(Color.LightGreen, New Point(500, 250), 0, Nothing, BoidList)
        FormDebug.AddMessage("Leader boid added at 500,250")
        Controls.Add(LeaderBoid.BirdPicture)
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        CurrentMousePosition = e.Location
    End Sub

    Private Sub Flock_Tick(sender As Object, e As EventArgs) Handles Flock.Tick
        FormDebug.ListBox1.Items.Clear()
        FormDebug.ListBox2.Items.Clear()

        Label1.Text = (BoidList.Count + 1).ToString
        LeaderBoid.Target = CurrentMousePosition
        LeaderBoid.FlyTo(10, CurrentMousePosition)
        Dim target As Boid = LeaderBoid

        For index = 0 To BoidList.Count - 1
            Dim Boid = BoidList(index)
            FormDebug.ListBox1.Items.Add(Boid.ToString())

            Boid.Target = target.Location
            Boid.FlyTo(10, Boid.Target)

        Next

        For index = 0 To ObstacleList.Count() - 1
            FormDebug.ListBox2.Items.Add(ObstacleList(index).ToString())
            Dim Obstacle = ObstacleList(index)
            Obstacle.FlyTo(Obstacle.Speed, Nothing) 'obstacles as they move in an constant direction so we dont need a target.
        Next

        RemoveBoidsInObstacles()


    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        AddNewBoid(e.Location)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp


        If e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control Then
            NewGame()
        ElseIf e.KeyCode = Keys.H AndAlso e.Modifiers = Keys.Control Then
            ShowDebugForm()
        ElseIf e.KeyCode = Keys.O AndAlso e.Modifiers = Keys.Control Then
            OpenFile()
        ElseIf e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control Then
            SaveFile()
        ElseIf e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then
            Application.Exit()
        ElseIf e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Control Then
            ShowHelp()
        ElseIf e.KeyCode = Keys.O Then
            AddObstacle()
        ElseIf e.KeyCode = Keys.B Then
            AddNewBoid(CurrentMousePosition)
        End If

    End Sub

#End Region

#Region "Methods"
    Private Sub AddNewBoid(location As Point)
        Dim Boid = New Boid(Color.Blue, location, BoidList.Count() + 1, LeaderBoid, BoidList)
        Controls.Add(Boid.BirdPicture)
        BoidList.Add(Boid)
        FormDebug.AddMessage("New boid added at " & location.X & "," & location.Y)
    End Sub

    Private Sub RemoveBoidsInObstacles()
        For i = 0 To BoidList.Count - 1
            'FormDebug.AddMessage("RemoveBoidsInObstacles - Boid index: " + i.ToString())
            If BoidList(i).MyBirdIndex = 0 Then
                Continue For
            End If
            For j = 0 To ObstacleList.Count - 1

                If (BoidList(i).Location.X >= ObstacleList(j).Location.X) _
                    And (BoidList(i).Location.X <= ObstacleList(j).Location.X + 50) _
                    And (BoidList(i).Location.Y >= ObstacleList(j).Location.Y) _
                    And (BoidList(i).Location.Y <= ObstacleList(j).Location.Y + 50) _
                Then
                    FormDebug.AddMessage("Boid removed :" & BoidList(i).MyBirdIndex)
                    Controls.Remove(BoidList(i).BirdPicture)
                    BoidList.RemoveAt(i)
                    RemoveBoidsInObstacles()
                    Return
                End If
            Next
        Next
    End Sub

    Private Sub AddObstacle()
        Dim position As Point
        Dim lc As LocationDialog = New LocationDialog()
        Dim dr As DialogResult = lc.ShowDialog()
        If dr = DialogResult.OK Then
            ' calculate position
            Dim precent As Integer = lc.Percent
            Dim speed As Integer = lc.Speed
            position.Y = Me.Height - Math.Round(Me.Height * precent / 100)
            position.X = Me.Width - Math.Round(Me.Width * precent / 100)
            Dim Obstacle = New Obstacle(position, ObstacleList.Count + 1, lc.type)
            Obstacle.Width = Me.Width
            Obstacle.Height = Me.Height
            Obstacle.Speed = speed
            Controls.Add(Obstacle.BirdPicture)
            ObstacleList.Add(Obstacle)
            FormDebug.AddMessage("Obstacle added :" & lc.type & " Speed " & lc.Speed)
            FormDebug.ListBox2.Items.Add(Obstacle.ToString())
        End If
    End Sub

    Private Sub ShowDebugForm()
        FormDebug.Show()
    End Sub

    Private Shared Sub ShowHelp()
        Dim FormHelp As New FormHelp()
        FormHelp.ShowDialog()
    End Sub


#End Region

#Region "New game, save, load game"

    Private Sub NewGame()
        NewGame(Nothing)
    End Sub

    Private Sub NewGame(GameData As Game)
        'Clear old data
        For i = 0 To BoidList.Count - 1
            Controls.Remove(BoidList(i).BirdPicture)
        Next
        BoidList.Clear()
        For i = 0 To ObstacleList.Count - 1
            Controls.Remove(ObstacleList(i).BirdPicture)
        Next
        ObstacleList.Clear()

        'laod data
        If Not IsNothing(GameData) Then
            LeaderBoid.Location = GameData.LeaderBoid.Location
            For Each Boid In GameData.BoidList
                Dim NewBoid = New Boid(Boid.BirdColour, Boid.Location, Boid.MyBirdIndex, LeaderBoid, BoidList)
                Controls.Add(NewBoid.BirdPicture)
                BoidList.Add(NewBoid)
            Next
            For Each obstacle In GameData.ObstacleList
                Dim NewObstacle = New Obstacle(obstacle.Location, obstacle.MyBirdIndex, obstacle.TypeOfObstacle)
                Controls.Add(NewObstacle.BirdPicture)
                ObstacleList.Add(NewObstacle)
            Next
        End If
    End Sub

    Private Sub SaveGame(FileNameToAtach As String)

        Dim game As New Game()
        game.BoidList = BoidList
        game.LeaderBoid = LeaderBoid
        game.ObstacleList = ObstacleList

        Dim settings As JsonSerializerSettings = New JsonSerializerSettings()
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore

        Dim json As String = JsonConvert.SerializeObject(game, Formatting.Indented, settings)
        File.Create(FileNameToAtach).Dispose()
        Dim line As New System.IO.StreamWriter(FileNameToAtach)
        line.WriteLine(json)
        line.Close()

    End Sub

    Private Sub LoadGame(FileToRead As String)

        Dim text As String = File.ReadAllText(FileToRead)

        Dim game As Game = JsonConvert.DeserializeObject(Of Game)(text)

        NewGame(game)
    End Sub

    Private Sub SaveFile()
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.Filter = "Felix's Boid Files | *.fboids"
        sfd.DefaultExt = "*.fboids"
        sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments
        sfd.AddExtension = True
        If sfd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = sfd.FileName
            SaveGame(filename)
        End If
    End Sub

    Private Sub OpenFile()
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Filter = "Felix's Boid Files | *.fboids"
        ofd.DefaultExt = "*.fboids"
        ofd.InitialDirectory = Environment.SpecialFolder.MyDocuments
        ofd.AddExtension = True
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim filename As String = ofd.FileName
            LoadGame(filename)
        End If
    End Sub

#End Region

#Region "Menu Events"
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFile()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim box = New AboutBox1()
        box.Show()
    End Sub

    Private Sub GetStartedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetStartedToolStripMenuItem.Click
        ShowHelp()
    End Sub
    Private Sub AddBoidToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBoidToolStripMenuItem.Click
        AddNewBoid(CurrentMousePosition)
    End Sub

    Private Sub NewCtrlNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCtrlNToolStripMenuItem.Click
        NewGame()
    End Sub

    Private Sub AddObstacleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddObstacleToolStripMenuItem.Click
        AddObstacle()
    End Sub

    Private Sub DebugWindowCtrlHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugWindowCtrlHToolStripMenuItem.Click
        ShowDebugForm()
    End Sub

#End Region

End Class
