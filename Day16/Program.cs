using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day16;

Console.WriteLine("Day 16");

var lines = File.ReadAllLines("Input.txt");

foreach (var line in lines)
{ 
    new Valve(line);
}

foreach (var valve in Valve.AllValves.Values.Where(v => v.FlowRate != 0))
{
    valve.CalculatePathsToOtherValvesWithFlow();
}

var start = Valve.AllValves["AA"];
start.CalculatePathsToOtherValvesWithFlow();

Stack<ValvePath> pathsToCheck = new();
foreach (var startValve in start.CostToMoveToOtherValveWithFlow)
{
    pathsToCheck.Push(new ValvePath(startValve.Key, startValve.Value));
}

ValvePath bestPath = null;
while (pathsToCheck.Count > 0)
{
    var currentPath = pathsToCheck.Pop();
    var currentValve = currentPath.Path.Last();
    bool done = true;

    foreach (var next in currentValve.CostToMoveToOtherValveWithFlow)
    {
        if (currentPath.Path.Contains(next.Key))
            continue;
        if (currentPath.RemainingTime - next.Value <= 0)
            continue;

        pathsToCheck.Push(new ValvePath(currentPath, next.Key, next.Value));
        done = false;
    }

    if (!done)
        continue;

    if (bestPath == null || currentPath.Score > bestPath.Score)
    {
        bestPath = currentPath;
    }
}
Console.WriteLine("Part 1: " + bestPath.Score);
Console.WriteLine("Starting part 2. Warning this is slow. >10min");

DualSimulation bestDualSimulation = null;

Stack<DualSimulation> dualSimulationToCheck = new();
foreach (var startValveA in start.CostToMoveToOtherValveWithFlow)
{
    foreach (var startValveB in start.CostToMoveToOtherValveWithFlow)
    {
        if (startValveA.Key == startValveB.Key)
            continue;
        dualSimulationToCheck.Push(new DualSimulation(startValveA.Key, startValveB.Key, startValveA.Value, startValveB.Value));
    }
}

while (dualSimulationToCheck.Count > 0)
{
    var currentDual = dualSimulationToCheck.Pop();
    
    var currentPath = currentDual.Human;
    var currentValve = currentPath.Path.Last();
    bool outOfOptionsOrTime = true;

    foreach (var next in currentValve.CostToMoveToOtherValveWithFlow)
    {
        if (currentDual.ValveOpen(next.Key))
            continue;
        if (currentPath.RemainingTime - next.Value <= 0)
            continue;

        dualSimulationToCheck.Push(new DualSimulation(currentDual, next.Key, next.Value, false));
        outOfOptionsOrTime = false;
    }

    if (outOfOptionsOrTime) //Lets simulate the elephant then
    {
        currentPath = currentDual.Elephant;
        currentValve = currentPath.Path.Last();
        outOfOptionsOrTime = true;

        foreach (var next in currentValve.CostToMoveToOtherValveWithFlow)
        {
            if (currentDual.ValveOpen(next.Key))
                continue;
            if (currentPath.RemainingTime - next.Value <= 0)
                continue;

            dualSimulationToCheck.Push(new DualSimulation(currentDual, next.Key, next.Value, true));
            outOfOptionsOrTime = false;
        }
    }

    if (outOfOptionsOrTime) //Both human and elephant is out of time
    {
        if (bestDualSimulation == null || currentDual.Score > bestDualSimulation.Score)
        {
            bestDualSimulation = currentDual;
        }
    }
}

Console.WriteLine("Part 2: " + bestDualSimulation.Score);