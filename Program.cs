using Raylib_cs;
using System.Numerics;



// dotnet add package Raylib-cs --version 4.2.0.1

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            // Game Formatting
            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var ScreenScore = 10;
            var MovementSpeed = 4;
            var positionX = 400;
            var positionY = 420;
            var Random = new Random();

            //Class Calls
            Score score = new Score();
            Player player = new Player();
            player.Position = new Vector2 (positionX, positionY);
            //Furthur Formating for window
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);
            var whichType = Random.Next(3);
            var Objects = new List<ObjectsMovement>();
            var Count = 0;
            Objects.Add(player);
            //Actual code
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText($"Score: {ScreenScore}", 12, 12, 20, Color.WHITE);

                // Gem and rock creation 
                Count +=1;
                if (Count == 60){
                    // Generate a random velocity for this object
                    var randomY = Random.Next(1, 3);
                    // Generate a placement for the object
                    var randomX = Random.Next(5, 795);
                    var randomSpeed = Random.Next(1, 3);
                    var square = new Gems(Color.GREEN, 20);
                    square.Position = new Vector2(randomX, randomY);
                    square.Velocity = new Vector2(0, randomSpeed);
                    Objects.Add(square);
                }

            
                if (Count == 60){
                    // Generate a random velocity for this object
                    var randomY2 = Random.Next(1, 3);
                    // Generate a placement for the object
                    var randomX2 = Random.Next(5, 795);
                    var randomSpeed2 = Random.Next(1, 3);
                    var square2 = new Rocks(Color.RED, 30);
                    square2.Position = new Vector2(randomX2,randomY2);
                    square2.Velocity = new Vector2(0, randomSpeed2);
                    Objects.Add(square2);
                    Count = 0;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    player.Position = new Vector2 (player.Position.X + MovementSpeed, player.Position.Y);
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    player.Position = new Vector2 (player.Position.X - MovementSpeed, player.Position.Y);
                }
                
                var Remove = new List<ObjectsMovement>();

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    if ((obj is Gems) || (obj is Rocks)){
                        if (Raylib.CheckCollisionRecs(player.Rectangle, ((ObjectSize)obj).Rectangle)) {
                            Remove.Add(obj);
                            if (obj is Gems){
                                ScreenScore = score.score(ScreenScore, 1);
                            }
                            else{
                                ScreenScore = score.score(ScreenScore, -1);
                            }
                        }
                    }
                    obj.Move();
                    if (obj.Position.Y > ScreenHeight){
                        Remove.Add(obj);
                    }
                }
                foreach (var obj in Remove) {
                    Objects.Remove(obj);
                }
            }

            Raylib.CloseWindow();
        }
    }
}