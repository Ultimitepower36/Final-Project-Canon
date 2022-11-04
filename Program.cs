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
            var ScreenScore = 0;
            var MovementSpeed = 4;
            var positionX = 700;
            var positionY = 420;
            var Random = new Random();

            //Class Calls
            Score score = new Score();
            Player player = new Player();

            var PlayerText = player.player("PlayerID");

            //Furthur Formating for window
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);
            var whichType = Random.Next(3);
            var Objects = new List<Gems>();
            var Objects2 = new List<Rocks>();
            //Actual code
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText($"Score: {ScreenScore}", 12, 12, 20, Color.WHITE);

                // Gem and rock creation 
                // Generate a random velocity for this object
                var randomY = Random.Next(-3, -1);
                // Generate a placement for the object
                var randomX = Random.Next(5, 795);
                var square = new Gems(Color.GREEN, 20);
                square.Position = new Vector2(randomX);
                square.Velocity = new Vector2(randomY);
                Objects.Add(square);

                

                // Generate a random velocity for this object
                var randomY2 = Random.Next(-3, -1);
                // Generate a placement for the object
                var randomX2 = Random.Next(5, 795);


                var square2 = new Rocks(Color.GRAY, 30);
                square.Position = new Vector2(randomX2);
                square.Velocity = new Vector2(randomY2);
                Objects2.Add(square2);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    positionX += MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    positionX -= MovementSpeed;
                }
                
                Raylib.DrawText($"{PlayerText}", positionX, positionY, 20, Color.WHITE);
/*
                if (Raylib.CheckCollisionRecs(PlayerRectangle, TargetRectangle)) {
                    Raylib.DrawText("You did it!!!!", 12, 34, 20, Color.BLACK);
                }
*/
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}