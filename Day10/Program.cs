using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Day 10");

var instructions = File.ReadLines("Input.txt").ToArray();

int cycle = 1;
int x = 1;
int signalStrength = 0;
string currentCrtLine = "#";

List<string> crt = new();

void Cycle()
{
    cycle++;
    var distance = Math.Abs(x - (currentCrtLine.Length + 0));
    currentCrtLine += distance <= 1 ? "#" : ".";
    if ((cycle + 20) % 40 == 0)
    {
        signalStrength += cycle * x;
        Console.WriteLine($"---- Cycle: {cycle}, x = {x}, signal = {signalStrength}");
    }
    if (cycle % 40 == 0)
    {
        crt.Add(currentCrtLine);
        currentCrtLine = "";
    }
}

for (int i = 0; i < instructions.Length; i++)
{
    if (instructions[i] == "noop")
    {
        Cycle();
    }
    else
    {
        var addAmount = int.Parse(instructions[i].Split(" ")[1]);
        Cycle();
        
        x += addAmount;

        Cycle();
    }
}

Console.WriteLine("Part 1: " + signalStrength);
Console.WriteLine("Part 2:");
foreach (var crtLine in crt)
    Console.WriteLine(crtLine);