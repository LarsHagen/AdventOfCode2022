using System;
using System.Collections.Generic;
using System.Linq;

namespace Day09
{
    public class Part2
    {
        private bool IsTailValid((int x, int y) tail, (int x, int y) head)
        {
            if (tail == head)
                return true;
            int xDist = Math.Abs(tail.x - head.x);
            int yDist = Math.Abs(tail.y - head.y);

            return xDist < 2 && yDist < 2;
        }
        
        private (int x, int y) MoveTail((int x, int y) tail, (int x, int y) head)
        {
            int xDist = Math.Abs(tail.x - head.x);
            int yDist = Math.Abs(tail.y - head.y);

            (int x, int y) newPosition = (head.x, head.y);

            if (yDist >= xDist)
            {
                //newPosition.x = head.x;
                newPosition.y = head.y > tail.y ? head.y - 1 : head.y + 1;
            }

            if (yDist <= xDist)
            {
                //newPosition.y = head.y;
                newPosition.x = head.x > tail.x ? head.x - 1 : head.x + 1;
            }
            
            /*if (yDist == xDist)
            {
                newPosition.y = head.y;
                newPosition.x = head.x > tail.x ? head.x - 1 : head.x + 1;
            }*/

            return newPosition;
        }

        public void Run(IEnumerable<string> enumerable)
        {
            List<(int x, int y)> positions = new();
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));
            positions.Add((0,0));

            HashSet<(int x, int y)> visitedPositions = new();
            visitedPositions.Add((0, 0));

            foreach (string command in enumerable)
            {
                var split = command.Split(" ");
                var amount = int.Parse(split[1]);

                (int x, int y) direction = split[0] switch
                {
                    "R" => (1, 0),
                    "L" => (-1, 0),
                    "U" => (0, 1),
                    "D" => (0, -1)
                };

                for (int i = 0; i < amount; i++)
                {
                    var head = positions[0];
                    positions[0] = (head.x + direction.x, head.y + direction.y);
                    
                    for (int j = 1; j < 10; j++)
                    {
                        if (IsTailValid(positions[j], positions[j - 1]))
                        {
                            continue;
                        }

                        positions[j] = MoveTail(positions[j], positions[j - 1]);
                    }
                    
                    if (!visitedPositions.Contains(positions[9]))
                        visitedPositions.Add(positions[9]);

                }
            }

            Console.WriteLine("Part 2: " + visitedPositions.Count);
        }
    }
}