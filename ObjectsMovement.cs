using Raylib_cs;
using System.Numerics;
class ObjectsMovement{
    public Vector2 speed(string user){
        var Random = new Random();

        // Generate a random velocity for this object
        var randomY = Random.Next(-3, -1);
        // Generate a placement for the object
        var randomX = Random.Next(5, 795);

        // Each object will start about the center of the screen
        var position = new Vector2(randomX, 0);
        return position;
    }
}