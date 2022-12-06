using System;
using System.IO;
using System.Linq;

int GetMarkerIndex(string s, int packageSize)
{
    for (int i = 0; i < s.Length - packageSize; i++)
    {
        var subString = s.Substring(i, packageSize);
        if (subString.Distinct().Count() == packageSize)
            return i + packageSize;
    }

    throw new Exception("This should not happen");
}

Console.WriteLine("Day 6");

var input = File.ReadAllText("Input.txt");

Console.WriteLine("Part 1: " + GetMarkerIndex(input, 4));
Console.WriteLine("Part 2: " + GetMarkerIndex(input, 14));