using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{   //counting the points in the game 
    public class Points
    {
            private int pointCount;

            public Points()
            {
                pointCount = 0;
            }

            public void AddPoint()
            {
                pointCount++;
            }

            public void WritePoints()
            {
                int xOffset = 1;
                int yOffset = 22;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(xOffset, yOffset);
                Console.Write($"Points: {pointCount}");
            }
        }



    }
