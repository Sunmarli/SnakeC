using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{      //creating  two obstacles in the game 
    internal class Obstacle
    {
        List<Figure> ObstacleList;        
        public Obstacle(int x, int y)
        {
            ObstacleList = new List<Figure>();

            // Отрисовка рамочки
            HorizontalLine UpperObstacle = new HorizontalLine(10, x - 16, 14, 'M');
            VerticalLine downObstacle = new VerticalLine(5, y - 1, 50, 'N');

            ObstacleList.Add(UpperObstacle);
            ObstacleList.Add(downObstacle);

        }

        internal bool IsHit(Figure figure)
        {
            foreach (var Obstacle in ObstacleList)
            {
                if (Obstacle.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            
            foreach (var Obstacle in ObstacleList)
            {
                
                Obstacle.Draw();
            }
        }
    }

}
