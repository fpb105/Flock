Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public MustInherit Class Bird
    <JsonProperty>
    Public MyBirdIndex As Integer
    Public BirdPicture As PictureBox
    <JsonProperty>
    Public BirdColour As Color
    Public MustOverride ReadOnly Property DebugMessage() As String
    Public MustOverride Sub DrawBoid()
    Public MustOverride Sub FlyTo(speed As Integer, TargetPosition As Point)

    <JsonProperty>
    Public Property Location() As Point
        Get
            Return BirdPicture.Location
        End Get
        Set
            BirdPicture.Location = Value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return DebugMessage
    End Function
End Class