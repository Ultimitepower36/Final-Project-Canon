using Raylib_cs;
using System.Numerics;

class ObjectsMovement : GenColor{
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
    
    
    public int Size { get; set; }

    public ObjectsMovement(Color color, int size): base(color) {
        Size = size;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

