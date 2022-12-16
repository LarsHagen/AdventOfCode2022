using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day15;

Console.WriteLine("Day 15");

//var lines = File.ReadAllLines("Example.txt"); int targetY = 10;
var lines = File.ReadAllLines("Input.txt"); int targetY = 2000000;
int minX = 0;
int maxX = 0;

List<SensorBeaconPair> sensorsAndBeacons = new();

foreach (var line in lines)
{
    var pair = new SensorBeaconPair(line);
    sensorsAndBeacons.Add(pair);

    minX = Math.Min(minX, pair.BeaconX);
    minX = Math.Min(minX, pair.SensorX);
    
    maxX = Math.Max(maxX, pair.BeaconX);
    maxX = Math.Max(maxX, pair.SensorX);
}

int count = 0;
int margin = 100000; // I honestly don't know why this is needed. But my result was too low and when I added a margin it was suddenly correct. Oh well
for (int x = minX - margin; x < maxX + margin; x++)
{
    if (sensorsAndBeacons.Any(s => s.BeaconX == x && s.BeaconY == targetY))
        continue;

    if (sensorsAndBeacons.Any(s => s.DistanceToSensor(x, targetY) <= s.DistanceToBeacon))
        count++;
}

Console.WriteLine("Part 1: " + count);

SensorBeaconPair lastHit = null;
int max = 4000000;
//max = 20;
for (int y = 0; y <= max; y++)
{
    if (y % 40000 == 0)
    {
        Console.WriteLine((int)((double)y / 4000000*100) + "%");
    }
    for (int x = 0; x <= max; x++)
    {
        var hit = sensorsAndBeacons.FirstOrDefault(s => s.DistanceToSensor(x, y) <= s.DistanceToBeacon);
        if (hit != null)
        {
            x = hit.GetXOutOfRange(y);
        }
        else
        {
            ulong part2 = (ulong) x * 4000000 + (ulong) y;
            Console.WriteLine("Part 2: " + part2);
            return;
        }
    }
}