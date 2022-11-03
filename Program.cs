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
            Gems Gems = new Gems();
            Rocks Rocks = new Rocks();

            var PlayerText = player.player("PlayerID");

            //Furthur Formating for window
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);
            var whichType = Random.Next(3);

            //Actual code
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText($"Score: {ScreenScore}", 12, 12, 20, Color.WHITE);

                // Gem Creation
                Gems.GemsCreation();
                Rocks.RockCreation();
                

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