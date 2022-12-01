using Raylib_cs;
using System.Numerics;
class Healthpack1 : Healthpack{
    public Healthpack1 (Color color, int size): base(color,size) {
        Value = 1;
    }

}
class Healthpack2 : Healthpack{
    public Healthpack2 (Color color, int size): base(color,size) {
        Value = 2;
    }
}
class Healthpack3 : Healthpack{
    public Healthpack3 (Color color, int size): base(color,size) {
        Value = 3;
    }
}