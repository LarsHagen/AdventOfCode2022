using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day14;

Console.WriteLine("Day 14");
var lines = File.ReadLines("Input.txt");

char[,] map = new char[1000,1000];
for (int y = 0; y < 1000; y++)
{
    for (int x = 0; x < 1000; x++)
    {
        map[x, y] = '.';
    }
}

int minX = int.MaxValue;
int minY = int.MaxValue;
int maxX = int.MinValue;
int maxY = int.MinValue;

foreach (var line in lines)
{
    List<(int x, int y)> points = new();
    foreach (var point in line.Split(" -> "))
    {
        var split = point.Split(",");
        var x = int.Parse(split[0]);
        var y = int.Parse(split[1]);
        points.Add((x,y));
        
        minY = Math.Min(minY, y);
        maxY = Math.Max(maxY, y);
        
        minX = Math.Min(minX, x);
        maxX = Math.Max(maxX, x);
    }

    for (int i = 0; i < points.Count - 1; i++)
    {
        var start = points[i];
        var end = points[i + 1];
        
        if (end.y != start.y)
        {
            int startY = Math.Min(start.y, end.y);
            int endY = Math.Max(start.y, end.y);
            
            
            
            for (int y = startY; y <= endY; y++)
            {
                
                
                map[start.x, y] = '#';
            }
        }
        
        if (end.x != start.x)
        {
            int startX = Math.Min(start.x, end.x);
            int endX = Math.Max(start.x, end.x);
            
            for (int x = startX; x <= endX; x++)
            {
                map[x, start.y] = '#';
            }
        }
    }
}

var sandSimulator = new SimulateSand();
int spawnedSand = 0;
var lastPathPart = sandSimulator.Simulate(ref map, maxY, ref spawnedSand);

for (int y = 0; y < maxY + 2; y++)
{
    string line = "";
    for (int x = minX - 1; x < maxX + 2; x++)
    {
        if (lastPathPart.Contains((x, y)))
        {
            line += '-';
        }
        else
            line += map[x, y];
    }
    Console.WriteLine(line);
}

Console.WriteLine("Part 1: " + (spawnedSand - 1));

maxY += 2;
minX = 1;
maxX = 999;
for (int x = minX; x < maxX; x++)
{
    map[x, maxY] = '#';
}

sandSimulator.Simulate(ref map, maxY, ref spawnedSand);

Console.WriteLine("Part 2: " + (spawnedSand - 1));