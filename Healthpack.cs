using Raylib_cs;
using System.Numerics;
class Healthpack : ObjectSize{
    public int Value {get; set;}
    public Healthpack (Color color, int size, int value): base(color,size) {
        Value = value;
    }
}


