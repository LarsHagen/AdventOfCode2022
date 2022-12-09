using System;
using System.Collections.Generic;

namespace Day09
{
    public class Part1
    {
        bool IsTailValid((int x, int y) tail, (int x, int y) head)
        {
            if (tail == head)
                return true;
            int xDist = Math.Abs(tail.x - head.x);
            int yDist = Math.Abs(tail.y - head.y);

            return xDist < 2 && yDist < 2;
        }
        
        (int x, int y) MoveTail((int x, int y) tail, (int x, int y) head)
        {
            int xDist = Math.Abs(tail.x - head.x);
            int yDist = Math.Abs(tail.y - head.y);

            (int x, int y) newPosition = (0, 0);

            if (yDist > xDist)
            {
                newPosition.x = head.x;
                newPosition.y = head.y > tail.y ? head.y - 1 : head.y + 1;
            }

            if (yDist < xDist)
            {
                newPosition.y = head.y;
                newPosition.x = head.x > tail.x ? head.x - 1 : head.x + 1;
            }

            return newPosition;
        }
        
        public void Run(IEnumerable<string> enumerable)
        {
            (int x, int y) headPosition = (0, 0);
            (int x, int y) tailPosition = (0, 0);

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
                    headPosition.x += direction.x;
                    headPosition.y += direction.y;

                    if (IsTailValid(tailPosition, headPosition))
                    {
                        continue;
                    }

                    tailPosition = MoveTail(tailPosition, headPosition);
                    if (!visitedPositions.Contains(tailPosition))
                        visitedPositions.Add(tailPosition);

                }
            }

            Console.WriteLine("Part 1: " + visitedPositions.Count);
        }
    }
}