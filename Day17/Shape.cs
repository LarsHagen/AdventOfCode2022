using System.Collections.Generic;
using System.Linq;

namespace Day17
{
    public class Shape
    {
        public bool[,] Map;
        public int Width;
        public int Height;
        public int X;
        public int Y;
        
        public bool CollisionDetection(Dictionary<int, List<bool>> occupied)
        {
            for (int y = 0; y < Height; y++)
            {
                if (!occupied.ContainsKey(Y + y))
                    break;

                for (int x = 0; x < Width; x++)
                {
                    bool shapeHere = Map[x, y];
                    if (!shapeHere)
                        continue;
                    bool occupiedHere = occupied[Y + y][X + x];
                    if (occupiedHere)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public void ParkHere(ref Dictionary<int, List<bool>> occupied)
        {
            for (int y = 0; y < Height; y++)
            {
                if (!occupied.ContainsKey(Y + y))
                {
                    var list = new List<bool>(7) {false, false, false, false, false, false, false};
                    occupied.Add(Y + y, list);
                }

                for (int x = 0; x < Width; x++)
                {
                    bool shapeHere = Map[x, y];
                    if (shapeHere)
                        occupied[Y + y][X + x] = true;
                }
            }
        }
        
        public static List<Shape> GetShapes()
        {
            List<Shape> list = new();

            list.Add(new Shape()
            {
                Map = new bool[,] {{true}, {true}, {true}, {true}},
                Height = 1,
                Width = 4
            });

            list.Add(new Shape()
            {
                Map = new bool[,] {{false, true, false}, {true, true, true}, {false, true, false}},
                Height = 3,
                Width = 3
            });

            list.Add(new Shape()
            {
                Map = new bool[,] {{true, false, false}, {true, false, false}, {true, true, true}},
                Height = 3,
                Width = 3
            });

            list.Add(new Shape()
            {
                Map = new bool[,] {{true, true, true, true}},
                Height = 4,
                Width = 1
            });

            list.Add(new Shape()
            {
                Map = new bool[,] {{true, true}, {true, true}},
                Height = 2,
                Width = 2
            });
            return list;
        }
    }
}