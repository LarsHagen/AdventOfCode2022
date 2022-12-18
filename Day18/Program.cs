using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day18;

Console.WriteLine("Day 17");

var lines = File.ReadAllLines("Input.txt");

HashSet<(int x, int y, int z)> lava = new();
HashSet<(int x, int y, int z)> water = new();
int maxX = 0;
int maxY = 0;
int maxZ = 0;
int exposedPart1 = 0;
int exposedPart2 = 0;

void CheckExposed(int x, int y, int z)
{
    if (!lava.Contains((x, y, z)))
    {
        exposedPart1++;
        if (water.Contains((x, y, z)))
            exposedPart2++;
    }
}

foreach (var line in lines)
{
    var coordinates = line.Split(",").Select(v => int.Parse(v)).ToArray();
    lava.Add((coordinates[0], coordinates[1], coordinates[2]));

    maxX = Math.Max(maxX, coordinates[0]);
    maxY = Math.Max(maxY, coordinates[1]);
    maxZ = Math.Max(maxZ, coordinates[2]);
}

YetAnotherGrassfire.Run(ref water, lava, maxX, maxY, maxZ);

for (int y = 0; y <= maxY; y++)
{
    for (int x = 0; x <= maxX; x++)
    {
        for (int z = 0; z <= maxZ; z++)
        {
            if (!lava.Contains((x,y,z)))
                continue;

            CheckExposed(x + 1, y, z);
            CheckExposed(x + 1, y, z);
            CheckExposed(x, y + 1, z);
            CheckExposed(x, y - 1, z);
            CheckExposed(x, y, z + 1);
            CheckExposed(x, y, z - 1);
        }
    }
}

Console.WriteLine("Part 1: " + exposedPart1);
Console.WriteLine("Part 2: " + exposedPart2);
