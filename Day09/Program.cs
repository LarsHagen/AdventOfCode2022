using System;
using System.IO;
using Day09;


Console.WriteLine("Day 9");

var lines = File.ReadLines("Input.txt");

new Part1().Run(lines);
new Part2().Run(lines);
