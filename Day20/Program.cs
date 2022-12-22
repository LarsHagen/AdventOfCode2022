using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day20;

List<Node> allNodes = new();
void SetPreviousAndNextOnAllNodes()
{
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
}

Console.WriteLine("Day 20");

var lines = File.ReadAllLines("Input.txt");

foreach (var t in lines)
{
    allNodes.Add(new Node()
    {
        Value = long.Parse(t)
    });
}

SetPreviousAndNextOnAllNodes();

HashSet<Node> burnedNodes = new();
List<Node> moveOrderingForPart2 = new();

while (burnedNodes.Count < allNodes.Count)
{
    Node current = Node.Start;

    while (burnedNodes.Contains(current))
        current = current.Next;

    burnedNodes.Add(current);
    moveOrderingForPart2.Add(current);

    long instruction = current.Value;

    for (long i = 0; i < Math.Abs(instruction); i++)
    {
        if (instruction < 0)
            current.MoveBack();
        else
            current.MoveForward();
    }
}

long sum = 0;
Node iteration = Node.Start;
while (iteration.Value != 0)
    iteration = iteration.Next;
for (long i = 1; i <= 3000; i++)
{
    iteration = iteration.Next;
    if (i % 1000 == 0)
    {
        sum += iteration.Value;
    }
}
Console.WriteLine("Part 1: " + sum);

SetPreviousAndNextOnAllNodes();
foreach (var node in allNodes)
{
    node.Value *= 811589153;
}

for (int mixCount = 0; mixCount < 10; mixCount++)
{
    burnedNodes.Clear();
    while (burnedNodes.Count < allNodes.Count)
    {
        Node current = moveOrderingForPart2[0];
        int nextNodeIndex = 0;

        while (burnedNodes.Contains(current))
        {
            nextNodeIndex++;
            current = moveOrderingForPart2[nextNodeIndex];
        }

        burnedNodes.Add(current);
        moveOrderingForPart2.Add(current);

        long instruction = current.Value;
        if (instruction > 0)
            instruction = instruction % (allNodes.Count - 1);
        else
            instruction = -Math.Abs(instruction % (allNodes.Count - 1));

        for (long i = 0; i < Math.Abs(instruction); i++)
        {
            if (instruction < 0)
                current.MoveBack();
            else
                current.MoveForward();
        }
    }

    /*string output = "";
    Node nodeToPrint = Node.Start;
    do
    {
        output += nodeToPrint.Value + ", ";
        nodeToPrint = nodeToPrint.Next;
    } while (nodeToPrint != Node.Start);

    Console.WriteLine(output);*/
}

sum = 0;
iteration = Node.Start;
while (iteration.Value != 0)
    iteration = iteration.Next;
for (long i = 1; i <= 3000; i++)
{
    iteration = iteration.Next;
    if (i % 1000 == 0)
    {
        sum += iteration.Value;
    }
}
Console.WriteLine("Part 2: " + sum);