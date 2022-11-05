using Raylib_cs;
using System.Numerics;

class Player: ObjectSize{
    
    public Player() : base(Color.WHITE,10) {

    }

    public override void Draw()
    {
        Raylib.DrawText("#", (int)this.Position.X, (int)this.Position.Y, 20, this.Color);

    }
}