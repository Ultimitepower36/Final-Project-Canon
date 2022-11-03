using Raylib_cs;
using System.Numerics;
class ObjectSize: GenColor{
    public int Size { get; set; }

    public ObjectSize(Color color, int size): base(color) {
        Size = size;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}

/*
    public int Size(){
        var sizeMod = 0;
        Random rnd = new Random();
        sizeMod = rnd.Next(4,15);
        return sizeMod;
    }
*/