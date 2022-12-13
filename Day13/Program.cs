using System;
using System.IO;
using System.Linq;
using Day13;

Console.WriteLine("Day 13");

var lines = File.ReadAllLines("Input.txt").ToArray();

var sum = 0;

for (int i = 0; i < lines.Length; i += 3)
{
    var left = new PackageData(lines[i]);
    var right = new PackageData(lines[i + 1]);

    var correct = left.CompareOrder(right);
    Console.WriteLine("Pair in order: " + correct);
    if (correct)
    {
        Console.WriteLine((i/3) + 1);
        sum += (i / 3) + 1;
    }
}

Console.WriteLine("Part 1: " + sum);