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
            var positionX = 400;
            var positionY = 420;
            var Random = new Random();


            //Class Calls
            Score score = new Score();
            Health Health = new Health();
            var change = 0;
            var Healthvalue = Health.Healthchange(change);

            Player player = new Player();
            player.Position = new Vector2 (positionX, positionY);


            //Furthur Formating for window
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);
            var whichType = Random.Next(3);
            var Objects = new List<ObjectsMovement>();
            var Count = 0;
            var Count2 = 0;
            Objects.Add(player);


            //Actual code
            while (!Raylib.WindowShouldClose())
            {
                //setup of screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText($"Score: {ScreenScore}", 12, 12, 20, Color.WHITE);
                Raylib.DrawText($"Health: {Healthvalue}", 12, 36, 20, Color.WHITE);

                // Health and Enemy creation 
                Count +=1;
                Count2 +=1;
                if (Count == 60 && Count2 == 240){
                    // Generate a random velocity for this object
                    var randomY = Random.Next(1, 3);

                    // Generate a placement for the object
                    var randomX = Random.Next(5, 795);

                    var randomSpeed = Random.Next(1, 4);
                    var colour = Color.BLACK;
                    var num = 0;
                    if (randomSpeed == 1){
                        colour = Color.GREEN;
                        num = 1;
                        }
                    else if(randomSpeed == 2){
                        colour = Color.BLUE;
                        num = 2;
                    }
                    else if(randomSpeed == 3){
                        colour = Color.PURPLE;
                        num = 3;
                    }
                    var square = new Healthpack(colour, 20, num);
                    square.Position = new Vector2(randomX, randomY);
                    square.Velocity = new Vector2(0, randomSpeed);
                    Objects.Add(square);
                    Count2 = 0;
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
                    if ((obj is Healthpack) || (obj is Rocks)){
                        if (Raylib.CheckCollisionRecs(player.Rectangle, ((ObjectSize)obj).Rectangle)) {
                            Remove.Add(obj);
                            if (obj is Healthpack){
                                change += 1;
                                Healthvalue = Health.Healthchange(change);
                            }
                            else{
                                change -= 1;
                                Healthvalue = Health.Healthchange(change);
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
//Add game over class?
//make sure polymorphism is utilized for health packs.
//Use different classes for each
// Make missle class (laser?)
//make sure collision works properly.
// Enemy = +10 points, Health = +5 points, starting health = 5, starting score = 0?100?