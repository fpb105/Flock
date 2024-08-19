Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)> 'this is to be able to save the game and use serialization
Public Class Game
    <JsonProperty>
    Public Property LeaderBoid As Boid
    <JsonProperty>
    Public Property BoidList As New List(Of Boid)
    <JsonProperty>
    Public Property ObstacleList As New List(Of Obstacle)

End Class