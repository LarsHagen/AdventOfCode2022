using System.Collections.Generic;

namespace Day18
{
    public static class YetAnotherGrassfire //I seem to be using grassfire a lot this year :-D
    {
        public static void Run(ref HashSet<(int x, int y, int z)> water, HashSet<(int x, int y, int z)> lava, int maxX, int maxY, int maxZ)
        {
            Queue<(int x, int y, int z)> toCheck = new();
            
            toCheck.Enqueue((-1,-1,-1));

            while (toCheck.Count > 0)
            {
                var point = toCheck.Dequeue();
                
                if (water.Contains(point))
                    continue;
                
                if (lava.Contains(point))
                    continue;
                
                if (point.x < -1)
                    continue;
                if (point.y < -1)
                    continue;
                if (point.z < -1)
                    continue;
                if (point.x > maxX + 1)
                    continue;
                if (point.y > maxY + 1)
                    continue;
                if (point.z > maxZ + 1)
                    continue;
                
                water.Add(point);
                
                toCheck.Enqueue((point.x + 1, point.y, point.z));
                toCheck.Enqueue((point.x - 1, point.y, point.z));
                toCheck.Enqueue((point.x, point.y + 1, point.z));
                toCheck.Enqueue((point.x, point.y - 1, point.z));
                toCheck.Enqueue((point.x, point.y, point.z + 1));
                toCheck.Enqueue((point.x, point.y, point.z - 1));
            }
        }
    }
}