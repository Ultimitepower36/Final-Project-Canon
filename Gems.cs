using Raylib_cs;
using System.Numerics;
class Gems : ObjectSize{

    public void GemsCreation(){
        var Objects = new List<Gems>();
        var Random = new Random();

        // Generate a random velocity for this object
        var randomY = Random.Next(-3, -1);
        // Generate a placement for the object
        var randomX = Random.Next(5, 795);


        var square = new ObjectSize(Color.GREEN, 50);
        square.Position = new Vector2(randomX);
        square.Velocity = new Vector2(randomY);
        Objects.Add(square);
    }
}