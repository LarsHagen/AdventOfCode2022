using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Day 8");

var lines = File.ReadLines("Input.txt").ToArray();

int height = lines.Count();
int width = lines[0].Length;

int[,] map = new int[width, height];

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        int treeHeight = int.Parse(lines[y][x].ToString());
        map[x, y] = treeHeight;
    }
}

HashSet<(int x, int y)> visible = new();

//Top to bottom
for (int x = 0; x < width; x++)
{
    int highest = -1;
    for (int y = 0; y < height; y++)
    {
        var key = (x, y);
        
        if (map[x, y] > highest)
        {
            highest = map[x, y];
            if (!visible.Contains(key))
                visible.Add(key);
        }
    }
}

//Bottom to top
for (int x = 0; x < width; x++)
{
    int highest = -1;
    for (int y = height - 1; y >= 0; y--)
    {
        var key = (x, y);
        
        if (map[x, y] > highest)
        {
            highest = map[x, y];
            if (!visible.Contains(key))
                visible.Add(key);
        }
    }
}

//Left to right
for (int y = 0; y < height; y++)
{
    int highest = -1;
    for (int x = 0; x < width; x++)
    {
        var key = (x, y);
        
        if (map[x, y] > highest)
        {
            highest = map[x, y];
            if (!visible.Contains(key))
                visible.Add(key);
        }
    }
}

//Right to left
for (int y = 0; y < height; y++)
{
    int highest = -1;
    for (int x = width - 1; x >= 0; x--)
    {
        var key = (x, y);
        
        if (map[x, y] > highest)
        {
            highest = map[x, y];
            if (!visible.Contains(key))
                visible.Add(key);
        }
    }
}

Console.WriteLine("Part 1: " + visible.Count);

//Find tree with best view
int bestView = 0;
for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        int treeHeight = map[x, y];
        
        int leftDistance = 0;
        for (int left = x - 1; left >= 0; left--)
        {
            leftDistance++;
            
            if (map[left, y] >= treeHeight)
                break;
        }
        
        int rightDistance = 0;
        for (int right = x + 1; right < width; right++)
        {
            rightDistance++;
            
            if (map[right, y] >= treeHeight)
                break;
        }
        
        int downDistance = 0;
        for (int down = y - 1; down >= 0; down--)
        {
            downDistance++;
            
            if (map[x, down] >= treeHeight)
                break;
        }
        
        int upDistance = 0;
        for (int up = y + 1; up < height; up++)
        {
            upDistance++;
            
            if (map[x, up] >= treeHeight)
                break;
        }

        int viewScore = leftDistance * rightDistance * upDistance * downDistance;
        if (viewScore > bestView)
        {
            bestView = viewScore;
        }
    }
}

Console.WriteLine("Part 2: " + bestView);