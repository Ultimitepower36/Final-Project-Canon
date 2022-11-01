using Raylib_cs;
using System.Numerics;



// dotnet add package Raylib-cs --version 4.2.0.1

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var ScreenScore = 0;
            var MovementSpeed = 4;
            var positionX = 700;
            var positionY = 420;
            
            Score score = new Score();
            Player player = new Player();
            var PlayerText = Player.player("PlayerID");


            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                
                Raylib.DrawText($"Score: {ScreenScore}", 12, 12, 20, Color.WHITE);

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