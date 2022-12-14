using System;
using System.Collections.Generic;

namespace Day14
{
    public class SimulateSand
    {
        public List<(int x, int y)> Simulate(ref char[,] map, int maxY, ref int spawnedSand)
        {
            
            bool fellOffTheEdge = false;
            //int spawnedSand = 0;
            
            List<(int x, int y)> lastPath = new();
            
            while (!fellOffTheEdge && map[500,0] == '.')
            {
                lastPath.Clear();
                (int x, int y) sand = new(500, 0);
                spawnedSand++;
                while (true)
                {
                    lastPath.Add(sand);
                    if (sand.y > maxY)
                    {
                        fellOffTheEdge = true;
                        break;
                    }
                    
                    if (map[sand.x, sand.y + 1] == '.')
                    {
                        sand.y += 1;
                        continue;
                    }
                    if (map[sand.x - 1, sand.y + 1] == '.')
                    {
                        sand.y += 1;
                        sand.x -= 1;
                        continue;
                    }
                    
                    if (map[sand.x + 1, sand.y + 1] == '.')
                    {
                        sand.y += 1;
                        sand.x += 1;
                        continue;
                    }
            
                    map[sand.x, sand.y] = 'O';
                    break;
                }
            }

            return lastPath;
        }
    }
}