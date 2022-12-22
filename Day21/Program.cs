using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day21;

Console.WriteLine("Day 21");

var lines = File.ReadAllLines("Input.txt");

Console.WriteLine("Part 1: " + Part1.Run(lines));
Console.WriteLine("Part 2: " + Part2.Run(lines));