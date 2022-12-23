using System;
using System.IO;
using System.Linq;
using Day22;

Console.WriteLine("Day 22");

var lines = File.ReadAllLines("Input.txt").ToList();

char[,] map;

var instructions = lines.Last();
lines.Remove(instructions);

int mapHeight = lines.Count - 1;
int mapWidth = lines.OrderByDescending(l => l.Length).First().Length;

map = new char[mapWidth, mapHeight];

int xDir = 1;
int yDir = 0;
int positionX = 0;
int positionY = 0;

for (int y = 0; y < mapHeight; y++)
{
    for (int x = 0; x < mapWidth; x++)
    {
        var line = lines[y];

        if (y == 0 && positionX == 0 && line[x] == '.')
            positionX = x;
        
        if (x >= line.Length)
            map[x, y] = ' ';
        else
            map[x, y] = line[x];
    }
}

Console.WriteLine("Part 1: " + Part1.Run(map, mapWidth, mapHeight, positionX, positionY, xDir, yDir, instructions));
Console.WriteLine("Part 2: " + Part2.Run(map, mapWidth, mapHeight, positionX, positionY, xDir, yDir, instructions));