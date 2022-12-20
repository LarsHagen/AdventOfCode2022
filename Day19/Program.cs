using System;
using System.Collections.Generic;
using System.IO;
using Day19;

Console.WriteLine("Day 19");

var lines = File.ReadAllLines("Input.txt");
List<Blueprint> blueprints = new();
foreach (var line in lines)
{
    blueprints.Add(new Blueprint(line));
}
Simulate simulate = new();

Console.WriteLine("Starting part 1. This is not pretty. Takes about 9 minutes");
int part1 = 0;
for (var index = 0; index < blueprints.Count; index++)
{
    Console.WriteLine("Blueprint: " + (index + 1));
    var blueprint = blueprints[index];
    int score = simulate.Run(blueprint);
    part1 += (index + 1) * score;
}

Console.WriteLine("Part 1: " + part1);

Console.WriteLine("Starting part 2. You thought that part 1 was slow? Maybe I should have done some multithreading here instead");
int part2 = 0;
for (var index = 0; index < Math.Min(blueprints.Count, 3); index++)
{
    Console.WriteLine("Blueprint: " + (index + 1));
    var blueprint = blueprints[index];
    int score = simulate.Run(blueprint, 32);
    if (part2 == 0)
        part2 = score;
    else
        part2 *= score;

}

Console.WriteLine("Part 2: " + part2);