using Raylib_cs;
class GenColor: ObjectsMovement {
    public Color Color { get; set; }

    public GenColor(Color color) {
        Color = color;
    }
}