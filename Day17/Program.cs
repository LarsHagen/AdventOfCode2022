using System;
using System.Collections.Generic;
using System.IO;
using Day17;


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

        Console.WriteLine(line);
    }
    Console.WriteLine();
}

Console.WriteLine("Day 17");

List<Shape> shapes = new();

//TODO: check if y should be reversed in map

shapes.Add(new Shape()
{
    Map = new bool[,] {{true}, {true}, {true}, {true}},
    Height = 1,
    Width = 4
});

shapes.Add(new Shape()
{
    Map = new bool[,] {{false, true, false},{true, true, true},{false, true, false}},
    Height = 3,
    Width = 3
});

shapes.Add(new Shape() //Wrong
{
    Map = new bool[,] {{true, false, false},{true, false, false},{true, true, true}},
    Height = 3,
    Width = 3
});

shapes.Add(new Shape()
{
    Map = new bool[,] {{true,true,true,true}},
    Height = 4,
    Width = 1
});

shapes.Add(new Shape()
{
    Map = new bool[,] {{true, true},{true, true}},
    Height = 2,
    Width = 2
});

var instructions = File.ReadAllLines("Input.txt")[0];

Dictionary<int, List<bool>> occupied = new();
int highestPoint = 0;

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
}

Console.WriteLine("Part 1: " + highestPoint);


