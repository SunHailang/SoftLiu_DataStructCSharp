using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication.AStar
{
    public class Grid
    {

        private int m_count = 0;
        public int Count
        {
            get { return m_count; }
        }

        public Spot[,] grid;

        public int gridCountX;
        public int gridCountY;

        public Grid(int[,] array)
        {
            gridCountX = array.GetLength(0);
            gridCountY = array.GetLength(1);

            grid = new Spot[gridCountX, gridCountY];

            for (int x = 0; x < gridCountX; x++)
            {
                for (int y = 0; y < gridCountY; y++)
                {
                    bool walkable = array[x, y] == 0;
                    grid[x, y] = new Spot(x, y, walkable);
                }
            }

            m_count = gridCountX * gridCountY;
        }

        public List<Spot> GetNeighbours(Spot spot)
        {
            List<Spot> neighbours = new List<Spot>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    // 忽略自己
                    if (x == 0 && y == 0) continue;
                    int checkX = spot.x + x;
                    int checkY = spot.y + y;
                    if (checkX >= 0 && checkX < gridCountX && checkY >= 0 && checkY < gridCountY)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }
            return neighbours;
        }

        public Spot GetGridSpot(int x, int y)
        {
            if (x >= 0 && x < gridCountX && y >= 0 && y < gridCountY)
            {
                return grid[x, y];
            }
            return null;
        }
    }
}
