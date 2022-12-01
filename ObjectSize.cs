using Raylib_cs;
using System.Numerics;
class ObjectSize: GenColor{
    public int Size { get; set; }

    public ObjectSize(Color color, int size): base(color) {
        Size = size;
    }

    public Rectangle Rectangle {
        get {
            return new Rectangle(this.Position.X, this.Position.Y, this.Size, this.Size);
        }
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Size, Size, Color);
    }
}