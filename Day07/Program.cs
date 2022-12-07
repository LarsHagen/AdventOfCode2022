using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Day 7");

Stack<string> currentPath = new();
Dictionary<string, ulong> foldersAndSizes = new();
HashSet<string> burnedFiles = new();

foreach (var line in File.ReadLines("Input.txt"))
{
    if (line == "$ cd /")
    {
        currentPath = new();
        currentPath.Push("/");
        continue;
    }

    if (line == "$ cd ..")
    {
        currentPath.Pop();
        continue;
    }

    if (line.Contains("$ cd "))
    {
        currentPath.Push(line.Replace("$ cd ", null));
        continue;
    }

    if (line.Contains("dir "))
    {
        continue;
    }
    
    if (line.Contains("$ ls"))
    {
        continue;
    }

    var split = line.Split(" ");
    ulong fileSize = ulong.Parse(split[0]);
    string path = "";

    var reversed = currentPath.Reverse().ToArray();
    
    foreach (var entry in reversed)
    {
        path += entry + "/";
    }

    string file = path + split[1];
    
    if (burnedFiles.Contains(file))
        continue;
    
    path = "";
    foreach (var entry in reversed)
    {
        path += entry + "/";
        if (!foldersAndSizes.ContainsKey(path))
            foldersAndSizes.Add(path, 0);

        foldersAndSizes[path] += fileSize;
    }
}

ulong part1Size = 0;

foreach (var entry in foldersAndSizes)
{
    if (entry.Value > 100000)
        continue;

    part1Size += entry.Value;
}

Console.WriteLine("Part 1: " + part1Size);

ulong totalUsedSpace = foldersAndSizes["//"];
ulong freeSpace = 70000000 - totalUsedSpace;
ulong neededSpace = 30000000 - freeSpace;
//Console.WriteLine("Total used space: " + totalUsedSpace);
//Console.WriteLine("Free space: " + freeSpace);
//Console.WriteLine("Needed space: " + neededSpace);

KeyValuePair<string, ulong> folderToDelete = new("Not this!", ulong.MaxValue);

foreach (var entry in foldersAndSizes)
{
    if (entry.Value < neededSpace)
        continue;
    
    if (entry.Value > folderToDelete.Value)
        continue;

    folderToDelete = entry;
}

Console.WriteLine("Part 2: " + folderToDelete.Value);