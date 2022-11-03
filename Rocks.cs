using Raylib_cs;
using System.Numerics;
class Rocks : ObjectSize{
    public void RockCreation(){
        // list of object Rocks
        var Objects = new List<Rocks>();
        var Random = new Random();

        // Generate a random velocity for this object
        var randomY = Random.Next(-3, -1);
        // Generate a placement for the object
        var randomX = Random.Next(5, 795);


        var square = new ObjectSize(Color.RED, 50);
        square.Position = new Vector2(randomX);
        square.Velocity = new Vector2(randomY);
        Objects.Add(square);
    }
    }

    
}