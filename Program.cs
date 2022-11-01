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
            var RectangleSize = 50;

            var PlayerRectangle = new Rectangle(ScreenWidth - (RectangleSize * 2), ScreenHeight - (RectangleSize * 2), RectangleSize, RectangleSize);
            
            Score score = new Score();
            
            var ScreenScore = 0;
            var MovementSpeed = 4;

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                ScreenScore = Score.score(ScreenScore, 0);
                
                Raylib.DrawText($"Score: {score}", 12, 12, 20, Color.BLACK);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    PlayerRectangle.x += MovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    PlayerRectangle.x -= MovementSpeed;
                }

                Raylib.DrawRectangleRec(PlayerRectangle, Color.RED);

                if (Raylib.CheckCollisionRecs(PlayerRectangle, TargetRectangle)) {
                    Raylib.DrawText("You did it!!!!", 12, 34, 20, Color.BLACK);
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}