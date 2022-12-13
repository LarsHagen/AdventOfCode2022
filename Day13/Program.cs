using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day13;

Console.WriteLine("Day 13");

var lines = File.ReadAllLines("Input.txt").ToArray();

var sum = 0;
List<PackageData> allPackages = new();

for (int i = 0; i < lines.Length; i += 3)
{
    var left = new PackageData(lines[i]);
    var right = new PackageData(lines[i + 1]);
    
    allPackages.Add(left);
    allPackages.Add(right);

    var correct = left.CompareOrder(right);
    if (correct)
    {
        //Console.WriteLine((i/3) + 1);
        sum += (i / 3) + 1;
    }
}

Console.WriteLine("Part 1: " + sum);

var decoderPackage1 = new PackageData("[[2]]");
var decoderPackage2 = new PackageData("[[6]]");
allPackages.Add(decoderPackage1);
allPackages.Add(decoderPackage2);
allPackages.Sort(new PackageCompare());
allPackages.Reverse();

int index1 = -1;
int index2 = -1;

for (var i = 0; i < allPackages.Count; i++)
{
    var package = allPackages[i];
    //Console.WriteLine(package.Input);

    if (package == decoderPackage1)
        index1 = i + 1;
    if (package == decoderPackage2)
        index2 = i + 1;
}

Console.WriteLine("Part 2: " + (index1 * index2));

