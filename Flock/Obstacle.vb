Imports Newtonsoft.Json

Public Class Obstacle : Inherits Bird
    <JsonProperty>
    Public TypeOfObstacle As String
    <JsonProperty>
    Friend Width As Integer
    <JsonProperty>
    Friend Height As Integer
    <JsonProperty>
    Friend Speed As Integer
    <JsonProperty>
    Friend MoveDirection As Integer = 1


    Public Overrides ReadOnly Property DebugMessage As String
        Get
            Return Me.MyBirdIndex & ": " & BirdPicture.Location.ToString() & "Speed: " & Speed & " Type " & TypeOfObstacle
        End Get
    End Property

    Public Overrides Sub DrawBoid()
        Dim p As New Pen(Color.Black, 2)
        Dim b As New SolidBrush(BirdColour)
        Dim g As System.Drawing.Graphics
        BirdPicture.Refresh()
        g = BirdPicture.CreateGraphics
        g.DrawRectangle(p, 0, 0, 50, 50)
    End Sub

    Public Sub New(startPoint As Point, index As Integer, type As String)
        BirdPicture = New PictureBox()
        BirdPicture.Size = New Size(50, 50)
        BirdPicture.Location = startPoint
        BirdColour = Color.Black
        MyBirdIndex = index
        TypeOfObstacle = type
    End Sub

    Public Overrides Sub FlyTo(speed As Integer, TargetPosition As Point)
        If TypeOfObstacle = "v" Then 'moves verticlly
            If BirdPicture.Top > Height Or BirdPicture.Top < 0 Then
                MoveDirection = -1 * MoveDirection
            End If
            BirdPicture.Top = BirdPicture.Top + speed * MoveDirection
        ElseIf TypeOfObstacle = "h" Then 'moves horizontally
            If BirdPicture.Left > Width Or BirdPicture.Left < 0 Then
                MoveDirection = -1 * MoveDirection
            End If
            BirdPicture.Left = BirdPicture.Left + speed * MoveDirection
        End If
        'no statemnet for sationary because they do not move
        DrawBoid()
    End Sub
End Class
