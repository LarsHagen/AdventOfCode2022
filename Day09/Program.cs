using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

Console.WriteLine("Day 9");

var lines = File.ReadLines("Input.txt");

(int x, int y) headPosition = (0,0);
(int x, int y) tailPosition = (0,0);

bool IsTailValid()
{
    if (tailPosition == headPosition)
        return true;
    int xDist = Math.Abs(tailPosition.x - headPosition.x);
    int yDist = Math.Abs(tailPosition.y - headPosition.y);

    return xDist < 2 && yDist < 2;
}

(int x, int y) MoveTail()
{
    int xDist = Math.Abs(tailPosition.x - headPosition.x);
    int yDist = Math.Abs(tailPosition.y - headPosition.y);

    (int x, int y) newPosition = (0, 0);

    if (yDist > xDist)
    {
        newPosition.x = headPosition.x;
        newPosition.y = headPosition.y > tailPosition.y ? headPosition.y - 1 : headPosition.y + 1;
    }
    
    if (yDist < xDist)
    {
        newPosition.y = headPosition.y;
        newPosition.x = headPosition.x > tailPosition.x ? headPosition.x - 1 : headPosition.x + 1;
    }

    return newPosition;
}

HashSet<(int x, int y)> visitedPositions = new();
visitedPositions.Add((0, 0));

foreach (string command in lines)
{
    var split = command.Split(" ");
    var amount = int.Parse(split[1]);

    (int x, int y) direction = split[0] switch
    {
        "R" => (1, 0),
        "L" => (-1, 0),
        "U" => (0,1),
        "D" => (0,-1)
    };

    for (int i = 0; i < amount; i++)
    {
        headPosition.x += direction.x;
        headPosition.y += direction.y;

        if (IsTailValid())
            continue;

        tailPosition = MoveTail();
        if (!visitedPositions.Contains(tailPosition))
            visitedPositions.Add(tailPosition);
    }
}

Console.WriteLine("Part 1: " + visitedPositions.Count);

