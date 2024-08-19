Public Class Boid : Inherits Bird
    Public Target As Point
    Public ProtectedRange As Integer = 20 'how close each boid is willing to get to one another
    Public ViewRange As Integer = 40 'how far they can see other boids
    Public DistanceToTarget As Integer
    Private LeaderBoid As Boid
    Private BoidList As New List(Of Boid)


    Public Overrides ReadOnly Property DebugMessage As String
        Get
            Return Me.MyBirdIndex & ": " & BirdPicture.Location.ToString() & " Target Distance: " & DistanceToTarget
        End Get
    End Property

    Public Overrides Sub DrawBoid()
        Dim p As New Pen(Color.Black, 2)
        Dim b As New SolidBrush(BirdColour)
        Dim g As System.Drawing.Graphics
        BirdPicture.Refresh()
        g = BirdPicture.CreateGraphics
        g.FillEllipse(b, 0, 0, 10, 10)
        g.DrawEllipse(p, 0, 0, 8, 8)
    End Sub

    Public Sub New(colour As Color, position As Point, index As Integer, Leader As Boid, Boids As List(Of Boid))
        BoidList = Boids
        LeaderBoid = Leader
        BirdPicture = New PictureBox()
        BirdPicture.Size = New Size(10, 10)
        BirdPicture.Location = position
        MyBirdIndex = index
        BirdColour = colour

        BirdPicture.BackColor = Color.Transparent
    End Sub

    Public Overrides Sub FlyTo(speed As Integer, TargetPosition As Point)
        Dim NextPosition As Point
        Dim MoveByHorizontalDistance = (BirdPicture.Location.X - TargetPosition.X) / speed
        Dim MoveByVerticalDistance = (BirdPicture.Location.Y - TargetPosition.Y) / speed

        NextPosition = CalculateBoidNextPosition(MoveByHorizontalDistance, MoveByVerticalDistance)

        If MyBirdIndex <> 0 Then
            For Each Boid In BoidList
                If DistanceFrom(Boid.Location, NextPosition) <= ProtectedRange _
                    And Boid.MyBirdIndex <> MyBirdIndex Then
                    FormDebug.AddMessage("Collison!")
                    NextPosition = CalculateBoidNextPosition(MoveByVerticalDistance + New Random().Next(-5, 5), -1 * MoveByHorizontalDistance)
                End If
            Next
            If LeaderBoid IsNot Nothing Then
                If DistanceFrom(LeaderBoid.Location, NextPosition) < ProtectedRange _
                And LeaderBoid.MyBirdIndex <> MyBirdIndex Then
                    FormDebug.AddMessage("Collison!")
                    NextPosition = CalculateBoidNextPosition(MoveByVerticalDistance + New Random().Next(-5, 5), -1 * MoveByHorizontalDistance)
                End If
            End If
        End If

        BirdPicture.Left = NextPosition.X
        BirdPicture.Top = NextPosition.Y

        DrawBoid()
    End Sub

    Private Function CalculateBoidNextPosition(MoveByHorizontalDistance As Double, MoveByVerticalDistance As Double) As Point
        If MyBirdIndex = 0 Then
            Dim NextPosition As Point = New Point()
            NextPosition.X = BirdPicture.Left - MoveByHorizontalDistance
            NextPosition.Y = BirdPicture.Top - MoveByVerticalDistance
            Return NextPosition
        End If

        Dim angle, length As Double
        Dim X, Y, dX, dY As Double


        X = BirdPicture.Left 'Initial X position
        Y = BirdPicture.Top 'Initial Y position

        dX = MoveByHorizontalDistance 'Initial X movement
        dY = MoveByVerticalDistance 'Initial Y movement

        length = Math.Sqrt(dX * dX + dY * dY) 'Length of the vector

        'Generate a random angle between -40 and 40 degrees
        Dim randomValue As Random = New Random()
        Dim value As Integer = randomValue.Next(-40, 40)
        FormDebug.AddMessage("Ramdom angle:" & value.ToString())

        angle = (Math.PI / 180) * (value)

        'Rotate the vector by the random angle
        dX = length * Math.Cos(angle)
        dY = length * Math.Sin(angle)

        If MoveByHorizontalDistance > 0 Then
            dX = Math.Abs(dX)
        Else
            dX = -1 * Math.Abs(dX)
        End If
        If MoveByVerticalDistance > 0 Then
            dY = Math.Abs(dY)
        Else
            dY = -1 * Math.Abs(dY)
        End If

        'Update the position of the object
        X = X - dX
        Y = Y - dY

        Dim result As Point = New Point(X, Y)

        result.X = X
        result.Y = Y

        Return result

    End Function

    'Function FlockAtTarget(BoidToLookFor As Boid, SortedList As List(Of Boid), OGLength As Integer) As Boolean
    '    Dim found As Boolean
    '    Dim FinalLegth As Integer
    '    For i = 0 To SortedList.Count - 1
    '        For j = 0 To BoidList.Count - 1
    '            If SortedList(i).MyBirdIndex = BoidList(j).MyBirdIndex Then
    '                Continue For
    '            ElseIf SortedList(i).DistanceFrom(BoidList(j).Location, SortedList(i).Location) <= ViewRange And BoidList(j).MyBirdIndex <> SortedList(i).MyBirdIndex Then
    '                SortedList.Add(BoidList(j))
    '            Else
    '                Continue For
    '            End If
    '        Next
    '    Next
    '    FinalLegth = SortedList.Count

    '    For i = 0 To FinalLegth - 1
    '        If SortedList(i).MyBirdIndex = BoidToLookFor.MyBirdIndex Then
    '            found = True
    '            Return found
    '        End If
    '    Next

    '    If FinalLegth >= OGLength Then
    '        found = False
    '        Return found
    '    Else
    '        FlockAtTarget(BoidToLookFor, SortedList, FinalLegth)
    '    End If
    'End Function

    'Function CenterOfNearByBoids(CurrentBoid As Boid) As Point
    '    Dim Center As Point
    '    Dim SurroundingBoids As New List(Of Boid)
    '    For i = 0 To BoidList.Count - 1
    '        If DistanceFrom(BoidList(i).Location, CurrentBoid.Location) <= ViewRange Then
    '            SurroundingBoids.Add(BoidList(i))
    '        End If
    '    Next

    '    For i = 0 To SurroundingBoids.Count - 1
    '        'getting sum of position of near by boid
    '        Center.X += SurroundingBoids(i).Location.X
    '        Center.Y += SurroundingBoids(i).Location.Y
    '    Next
    '    'getting average of position of near by boid
    '    Center.X = Center.X / SurroundingBoids.Count
    '    Center.Y = Center.Y / SurroundingBoids.Count
    '    Return Center
    'End Function

    Function DistanceFrom(OtherBoidLocation As Point, Position As Point) As Integer
        Dim distance As Integer
        distance = Math.Sqrt(Math.Pow(OtherBoidLocation.X - Position.X, 2) + Math.Pow(OtherBoidLocation.Y - Position.Y, 2))
        Return distance
    End Function
End Class
