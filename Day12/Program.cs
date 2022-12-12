using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day12;

Console.WriteLine("Day 12");

var lines = File.ReadAllLines("Input.txt").ToArray();

var map = new Map(lines);

var grassfire = new Grassfire();
grassfire.Run(map);
Console.WriteLine("Part 1: " + map.Target.Steps(false));


int bestRoute = int.MaxValue;
foreach (Node n in map.Nodes.Values)
{
    if (n.Height != 'a')
        continue;
    map.ResetMap();
    map.Root = n;
    grassfire.Run(map);
    var score = map.Target.Steps(false);

    if (score < bestRoute)
        bestRoute = score;
}
Console.WriteLine("Part 2: " + bestRoute);