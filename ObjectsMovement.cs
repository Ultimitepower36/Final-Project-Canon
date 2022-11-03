using Raylib_cs;
using System.Numerics;

class ObjectsMovement{

    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);
    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }
    public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}
/*
public void speed(string user){
        var Random = new Random();

        // Generate a random velocity for this object
        var randomY = Random.Next(-3, -1);
        // Generate a placement for the object
        var randomX = Random.Next(5, 795);

        // Each object will start about the center of the screen
        var position = new Vector2(randomX, 0);
    }
    */