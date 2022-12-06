using Raylib_cs;
using System.Numerics;
class Bullets: ObjectSize{
    public Bullets(Color color, int size): base(color,size) {

    }
    public override Rectangle Rectangle(){
            return new Rectangle(this.Position.X, this.Position.Y, (this.Size/2), this.Size);
    }
    
}