using SnakeC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Numerics;
using System.Threading;
using WMPLib;


namespace SnakeC
{
    class Program
    {
        static int pointCount = 0;

        static void Main(string[] args)
        {
            Sounds sounds = new Sounds(@"C:\Users\Maria\source\repos\Sunmarli\SnakeC\SnakeC\Resources\");

            // Play the background music
            sounds.PlayBackground();


            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 20);
            walls.Draw();
            Obstacle Obst = new Obstacle(40, 10);
            Obst.Draw();


            // Отрисовка точек			
            Point p = new Point(4, 5, 'o');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 20, 'x');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Points points = new Points(); // Create a new Points object
 

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || Obst.IsHit(snake))
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    pointCount++;
                    points.AddPoint();
                    points.WritePoints();
                    sounds.PlayEat();
                    
                }
                else
                {
                    snake.Move();
                }
                

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                if (pointCount >= 5)
                {
                    Thread.Sleep(60);
                }
                else if (pointCount >= 2)
                {
                    Thread.Sleep(80);
                }
                else
                {
                    Thread.Sleep(100);
                }


            }
            WriteGameOver();
            sounds.PlayGameOver();// Stop music playback
            sounds.StopAll();
            Console.ReadLine();
        }




        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("GAME OVER", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("============================", xOffset, yOffset++);

        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
