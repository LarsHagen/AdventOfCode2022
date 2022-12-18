using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Day 17");

var lines = File.ReadAllLines("Input.txt");

HashSet<(int x, int y, int z)> cubes = new();
int maxX = 0;
int maxY = 0;
int maxZ = 0;

foreach (var line in lines)
{
    var coordinates = line.Split(",").Select(v => int.Parse(v)).ToArray();
    cubes.Add((coordinates[0], coordinates[1], coordinates[2]));

    maxX = Math.Max(maxX, coordinates[0]);
    maxY = Math.Max(maxY, coordinates[1]);
    maxZ = Math.Max(maxZ, coordinates[2]);
}

int exposed = 0;
for (int y = 0; y <= maxY; y++)
{
    for (int x = 0; x <= maxX; x++)
    {
        for (int z = 0; z <= maxZ; z++)
        {
            if (!cubes.Contains((x,y,z)))
                continue;

            if (!cubes.Contains((x + 1, y, z)))
                exposed++;
            if (!cubes.Contains((x - 1, y, z)))
                exposed++;
            if (!cubes.Contains((x, y + 1, z)))
                exposed++;
            if (!cubes.Contains((x, y - 1, z)))
                exposed++;
            if (!cubes.Contains((x, y, z + 1)))
                exposed++;
            if (!cubes.Contains((x, y, z - 1)))
                exposed++;
        }
    }
}

Console.WriteLine(exposed);
