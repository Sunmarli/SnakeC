using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{   //How game over sighn is made
    public static class ConsoleUtils
    {
        public static void WriteGameOver()
        {
            Console.Clear();
            int xOffset = 25;
            int yOffset = 6;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("       GAME OVER", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("============================", xOffset, yOffset++);
        }

        public static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }

}
