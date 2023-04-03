using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System;
    using System.IO;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace SnakeC
    {   //saving the data of player (name,score) to the file and reading the data from this file, writing to the screen 
        public class ScoreManager
        {
            private string scoresFile = "C:\\Users\\Maria\\source\\repos\\Sunmarli\\SnakeC\\SnakeC\\Nimed.txt";
            private string playerName;

            public void WriteScores(int score) 
            { //*Writes the scores to te txt file
                Console.Write("Enter your name: ");
                playerName = Console.ReadLine();

                while (playerName.Length < 3)
                {
                    Console.Write("Please enter a name with at least 3 characters: ");
                    playerName = Console.ReadLine();
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Users\Maria\source\repos\Sunmarli\SnakeC\SnakeC\Nimed.txt", true))
                {
                    writer.WriteLine("{0}, {1}", playerName, score);
                }
            }
        public static void PrintHighScores() //reads the lines from the txt and writes them to the screen by decreasing order
        {
            try
            {
                string[] lines = File.ReadAllLines(@"C:\Users\Maria\source\repos\Sunmarli\SnakeC\SnakeC\Nimed.txt");
                List<(string, int)> scores = new List<(string, int)>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0].Trim();
                    int score = int.Parse(parts[1].Trim());
                    scores.Add((name, score));
                }

                scores = scores.OrderByDescending(s => s.Item2).ToList();

                Console.WriteLine("High Scores:");
                Console.WriteLine("------------");

                foreach ((string name, int score) in scores)
                {
                    Console.WriteLine($"{name}: {score}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }


    }
}

