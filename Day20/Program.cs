using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day20;

Console.WriteLine("Day 20");


var lines = File.ReadAllLines("Input.txt");

List<Node> allNodes = new();

foreach (var t in lines)
{
    allNodes.Add(new Node()
    {
        Value = int.Parse(t)
    });
}

for (int i = 0; i < allNodes.Count; i++)
{
    if (i == 0)
    {
        allNodes[i].Previous = allNodes[^1];
        allNodes[i].Next = allNodes[i + 1];
        Node.Start = allNodes[i];
    }
    else if (i == allNodes.Count - 1)
    {
        allNodes[i].Previous = allNodes[i - 1];
        allNodes[i].Next = allNodes[0];
    }
    else
    {
        allNodes[i].Previous = allNodes[i - 1];
        allNodes[i].Next = allNodes[i + 1];
    }
}

HashSet<Node> burnedNodes = new();

while (burnedNodes.Count < allNodes.Count)
{
    Node current = Node.Start;

    while (burnedNodes.Contains(current))
        current = current.Next;

    burnedNodes.Add(current);

    int instruction = current.Value;

    for (int i = 0; i < Math.Abs(instruction); i++)
    {
        if (instruction < 0)
            current.MoveBack();
        else
            current.MoveForward();
    }
    
    //Print
    /*Node printNode = Node.Start;
    string output = "";
    do
    {
        output += printNode.Value + ", ";
        printNode = printNode.Next;
    } while (printNode != Node.Start);*/
    string output = $"{burnedNodes.Count}/{allNodes.Count}";
    Console.WriteLine(output);
}

int sum = 0;
Node iteration = Node.Start;
while (iteration.Value != 0)
    iteration = iteration.Next;
for (int i = 1; i <= 3000; i++)
{
    iteration = iteration.Next;
    if (i % 1000 == 0)
    {
        Console.WriteLine(iteration.Value);
        sum += iteration.Value;
    }
}
Console.WriteLine("Part 1: " + sum);