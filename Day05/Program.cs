using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Hello, World!");

List<Stack<char>> crateStacks = new();

var allLines = File.ReadLines("Input.txt").ToList();

//Get info for stack creation
var stackCountLine = allLines.First(x => x.Contains(" 1 "));
var stackCountLineIndex = allLines.IndexOf(stackCountLine);
var stackCount = int.Parse(stackCountLine[^2].ToString());

//Init stacks
for (int i = 0; i< stackCount;i++)
    crateStacks.Add(new());

//Parse stacks
for (int i = stackCountLineIndex - 1; i >= 0; i--)
{
    for (int j = 0; j < stackCount; j++)
    {
        var target = allLines[i][j * 4 + 1];
        if (target == ' ')
            continue;
        
        crateStacks[j].Push(target);
    }
}

//Parse and execute moves
for (int i = stackCountLineIndex + 2; i < allLines.Count; i++)
{
    var split = allLines[i].Split(' ');
    var amount = int.Parse(split[1]);
    var from = int.Parse(split[3]) - 1;
    var to = int.Parse(split[5]) - 1;

    for (int j = 0; j < amount; j++)
    {
        crateStacks[to].Push(crateStacks[from].Pop());
    }
}

//Get result
string result = "";
foreach (var stack in crateStacks)
{
    result += stack.Peek();
}

Console.WriteLine("Part 1: " + result);
