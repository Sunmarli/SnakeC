using SnakeC;
using System.Numerics;
using System.Security.Cryptography;

namespace Snake
{
    class Program
    {
        static void Main( string[] args )
        {   
            Point p1 = new Point(1,3,'*');
            /*p1.x = 1;
            p1.y = 3;
            p1.sym = '*';*/
            p1.Draw();

            Point p2 = new Point(4,5,'$');
            p2.Draw();

            HorizontalLine Line = new HorizontalLine(5,10,8,'+');
            Line.Drow();



            Console.ReadLine();
        }
        }
    }
