using System;
using System.Collections.Generic;
using System.IO;
using Day17;

//Part 2 is a mess :-(

void Print(Dictionary<int, List<bool>> occupiedToPrint, Shape optionalShape)
{
    
    int startY = occupiedToPrint.Count - 1;
    
    if (optionalShape != null)
        startY = Math.Max(startY, optionalShape.Y + optionalShape.Height);
    
    for (int y = startY; y >= 0; y--)
    {
        string line = "";
        if (occupiedToPrint.ContainsKey(y))
        {
            foreach (var blabla in occupiedToPrint[y])
            {
                line += blabla ? "#" : ".";
            }
        }
        else
        {
            line += ".......";
        }

        if (optionalShape != null)
        {
            var lineAsArray = line.ToCharArray();
            for (int x = 0; x < 7; x++)
            {
                var localX = x - optionalShape.X;
                var localY = y - optionalShape.Y;
                if (localX >= 0 && localX < optionalShape.Width &&
                    localY >= 0 && localY < optionalShape.Height)
                    if (optionalShape.Map[localX,localY])
                        lineAsArray[x] = 'O';
            }

            line = new string(lineAsArray);
        }

        Console.WriteLine(y.ToString("D4") + " " + line);
    }
    Console.WriteLine();
}

Console.WriteLine("Day 17");

var shapes = Shape.GetShapes();
var instructions = File.ReadAllLines("Input.txt")[0];

Dictionary<int, List<bool>> occupied = new();
int highestPoint = 0;

List<(int x, int highestPoint, int shapeID)> history = new();

int instructionIndex = 0;
    
for (int iteration = 0; iteration < 2022; iteration++)
{
    var shape = shapes[iteration % 5];
    shape.X = 2;
    shape.Y = highestPoint + 3; //TODO check if this should be 3
    
    while (true)
    {
        var instruction = instructions[instructionIndex];
        instructionIndex++;
        if (instructionIndex >= instructions.Length)
            instructionIndex = 0;
        
        int startX = shape.X;
        
        bool left = instruction == '<';
        
        if (left && shape.X > 0)
            shape.X--;
        else if (!left && shape.X + shape.Width < 7)
            shape.X++;

        if (shape.X != startX)
        {
            //collision detection sideways
            if (shape.CollisionDetection(occupied))
                shape.X = startX;
        }

        shape.Y--;
        //collision detection down
        bool hit = shape.CollisionDetection(occupied);

        if (hit || shape.Y < 0)
        {
            shape.Y++;
            shape.ParkHere(ref occupied);
            //Console.WriteLine(instruction + " Park here");
            //Print(occupied, null);

            if (shape.Y + shape.Height > highestPoint)
            {
                highestPoint = shape.Y + shape.Height;
            }
            break;
        }
        else
        {
            //Console.WriteLine(instruction);
            //Print(occupied, shape);
        }
    }
    
    history.Add((shape.X, highestPoint, iteration % 5));
}
Console.WriteLine("Part 1: " + highestPoint);
//Print(occupied, null);

List<(int x, int highestPoint, int shapeID)> last = new();
int sectionCount = 5;
for (int i = 2022 - 1; i >= 2022 - sectionCount; i--)
{
    last.Add(history[i]);
}

//Find pattern. Look from back
int repeatSectionIterations = 0;
int repeatSectionHeight = 0;
for (int i = 2022 - sectionCount - 1; i >= 0; i--)
{
    List<(int x, int highestPoint, int shapeID)> shapesToTest = new();
    for (int j = 0; j < sectionCount; j++)
    {
        shapesToTest.Add(history[i - j]);
    }

    if (HistorySectionEqual(last, shapesToTest))
    {
        Console.WriteLine("Found pattern at " + i);
        repeatSectionIterations = 2022 - i - 1;
        repeatSectionHeight = highestPoint - history[i].highestPoint;
        break;
    }
}

Console.WriteLine("Section height " + repeatSectionHeight);
Console.WriteLine("Iterations in section" + repeatSectionIterations);
Console.WriteLine("Done");


long remainingIterations = 1000000000000 - 2022;
Console.WriteLine("Remaining iterations " + remainingIterations);
long sectionsInRemainingIterations = remainingIterations / (repeatSectionIterations);
Console.WriteLine("Sections " + sectionsInRemainingIterations);
long heightOfSections = sectionsInRemainingIterations * repeatSectionHeight;

long actualIterationsCoveredByRemainingSections = sectionsInRemainingIterations * (repeatSectionIterations);


remainingIterations = remainingIterations - actualIterationsCoveredByRemainingSections - 1;

Console.WriteLine("Iterations still to simulate " + remainingIterations);

//Don't know why, but for example input use this for loop instead
//for (int iteration = 2022; iteration < 2022 + remainingIterations; iteration++)
for (int iteration = 2022; iteration <= 2022 + remainingIterations; iteration++)
{
    var shape = shapes[iteration % 5];
    shape.X = 2;
    shape.Y = highestPoint + 3; //TODO check if this should be 3
    
    while (true)
    {
        var instruction = instructions[instructionIndex];
        instructionIndex++;
        if (instructionIndex >= instructions.Length)
            instructionIndex = 0;
        
        int startX = shape.X;
        
        bool left = instruction == '<';
        
        if (left && shape.X > 0)
            shape.X--;
        else if (!left && shape.X + shape.Width < 7)
            shape.X++;

        if (shape.X != startX)
        {
            //collision detection sideways
            if (shape.CollisionDetection(occupied))
                shape.X = startX;
        }

        shape.Y--;
        //collision detection down
        bool hit = shape.CollisionDetection(occupied);

        if (hit || shape.Y < 0)
        {
            shape.Y++;
            shape.ParkHere(ref occupied);
            //Console.WriteLine(instruction + " Park here");
            //Print(occupied, null);

            if (shape.Y + shape.Height > highestPoint)
            {
                highestPoint = shape.Y + shape.Height;
            }
            break;
        }
        else
        {
            //Console.WriteLine(instruction);
            //Print(occupied, shape);
        }
    }
    
    history.Add((shape.X, highestPoint, iteration % 5));
}

long part2 = highestPoint + heightOfSections;

Console.WriteLine("Part 2: " + part2);

bool HistorySectionEqual(List<(int x, int highestPoint, int shapeID)> a, List<(int x, int highestPoint, int shapeID)> b)
{
    for (int i = 0; i < a.Count; i++)
    {
        if (a[i].x != b[i].x || a[i].shapeID != b[i].shapeID)
            return false;
    }

    return true;
}