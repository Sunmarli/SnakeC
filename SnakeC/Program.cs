using SnakeC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading;
using WMPLib;

//Создать класс препядствия для змейки и конец игры после врезания в препядствие
//Создать класс Очки для подсчета очков в игре и вывод их на экран в реальном времени
//Создать класс для показа конца игры 
//Создать класс для записи и вывода результатов в файл и на экран 
//Создать Класс для проигрывания музыки и звуков в игре 
//Ускорить змейку при проходе через определенное значение очков 


namespace SnakeC
{
    class Program
    {
        static int pointCount = 0;

        static void Main(string[] args)
        {
            
            Sounds sounds = new Sounds(@"C:\Users\Maria\source\repos\Sunmarli\SnakeC\SnakeC\Resources\");
            sounds.PlayBackground(); // Play the background music

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
                if (pointCount >= 5) //speed up the snake if poins are incresing
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
            ConsoleUtils.WriteGameOver();// Writes game over screen
            sounds.PlayGameOver();// Stop music playback
            sounds.StopAll();
            ScoreManager scoreManager = new ScoreManager(); 
            scoreManager.WriteScores(pointCount);

            ScoreManager.PrintHighScores();//writes score table

            Console.ReadLine();
            
        }

    }
}
