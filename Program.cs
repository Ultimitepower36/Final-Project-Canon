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
            var Bullets = new List<ObjectsMovement>();
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

                //Healthpack creation
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
                
                //enemy creation
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

                //player controls
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    player.Position = new Vector2 (player.Position.X + MovementSpeed, player.Position.Y);
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    player.Position = new Vector2 (player.Position.X - MovementSpeed, player.Position.Y);
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
                    var bullet = new Bullets(Color.YELLOW, 20);
                    bullet.Position = new Vector2(player.Position.X, player.Position.Y);
                    bullet.Velocity = new Vector2(0, -4);
                    Bullets.Add(bullet);
                }
                
                var Remove = new List<ObjectsMovement>();

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }
                foreach (var bullet in Bullets) {
                    bullet.Draw();
                }

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    if ((obj is Healthpack) || (obj is Rocks)){
                        if (Raylib.CheckCollisionRecs(player.Rectangle(), ((ObjectSize)obj).Rectangle())) {
                            Remove.Add(obj);
                            if (obj is Healthpack){
                                //changing the health increase based on pack
                                var hp = (Healthpack)obj;
                                change += hp.Value;
                                Healthvalue = Health.Healthchange(change);
                            }
                            else{
                                //enemy colission
                                change -= 1;
                                Healthvalue = Health.Healthchange(change);
                                if (Healthvalue <= 0){
                                    Raylib.CloseWindow();
                                }
                            }
                        }
                        if (obj is Rocks){
                            foreach (var bullet in Bullets) {
                                if (Raylib.CheckCollisionRecs(((ObjectSize)bullet).Rectangle(), ((ObjectSize)obj).Rectangle())) {
                                    Remove.Add(obj);
                                    Remove.Add(bullet);
                                    if (obj is Rocks){
                                        ScreenScore = score.score(ScreenScore, 10);
                                    }
                                }
                            }
                        }
                    }
                    obj.Move();
                    if ((obj.Position.Y > ScreenHeight) || (obj.Position.Y < (-10))){
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