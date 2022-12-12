using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day12;

Console.WriteLine("Day 12");

var lines = File.ReadAllLines("Input.txt").ToArray();

//Create map
int mapWidth = lines[0].Length;
int mapHeight = lines.Length;

Dictionary<(int x, int y), Node> mapped = new();
Node root = new(null, 0,0);// = new Node(null, start.x, start.y);
Node target = new(null, 0,0);// = new Node(null, goal.x, goal.y);

for (int y = 0; y < mapHeight; y++)
{
    var currentLine = lines[y];
    for (int x = 0; x < mapWidth; x++)
    {
        var currentChar = currentLine[x];

        if (currentChar == 'S')
        {
            //start = (x, y);
            //currentChar = 'a';
            root = new Node('a', x, y);
            mapped.Add(root.position, root);
        }
        else if (currentChar == 'E')
        {
            //goal = (x, y);
            //currentChar = 'z';
            target = new Node('z', x, y);
            mapped.Add(target.position, target);
        }
        else
        {
            mapped.Add((x,y), new Node(currentChar, x, y));
        }
        //map[x, y] = currentChar;
    }
}

Queue<Node> nodesToCheck = new();
HashSet<Node> burned = new();

nodesToCheck.Enqueue(root);

while (nodesToCheck.Any())
{
    var currentNode = nodesToCheck.Dequeue();
    List<Node> neighbours = new();

    if (mapped.ContainsKey((currentNode.position.x, currentNode.position.y + 1)))
    {
        neighbours.Add(mapped[(currentNode.position.x, currentNode.position.y + 1)]);
    }
    if (mapped.ContainsKey((currentNode.position.x, currentNode.position.y - 1)))
    {
        neighbours.Add(mapped[(currentNode.position.x, currentNode.position.y - 1)]);
    }
    if (mapped.ContainsKey((currentNode.position.x + 1, currentNode.position.y)))
    {
        neighbours.Add(mapped[(currentNode.position.x + 1, currentNode.position.y)]);
    }
    if (mapped.ContainsKey((currentNode.position.x - 1, currentNode.position.y)))
    {
        neighbours.Add(mapped[(currentNode.position.x - 1, currentNode.position.y)]);
    }

    var potentialNewDistance = currentNode.Steps(true) + 1;
    
    foreach (var neighbour in neighbours)
    {
        if (neighbour == root)
            continue;
        
        if (neighbour.Height - currentNode.Height > 1)
            continue;

        if (neighbour.Steps(false) <= potentialNewDistance)
            continue;

        neighbour.Previous = currentNode;
        
        if (burned.Contains(neighbour))
            continue;
        
        if (nodesToCheck.Contains(neighbour))
            continue;
        
        nodesToCheck.Enqueue(neighbour);
    }

    burned.Add(currentNode);
}

Console.WriteLine(target.Steps(false));