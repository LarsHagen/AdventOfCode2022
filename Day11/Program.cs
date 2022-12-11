using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day11;

Console.WriteLine("Day 11");

var lines = File.ReadAllLines("Input.txt");
List<Monkey> monkeys = new();

for (int i = 0; i < lines.Length; i += 7)
{
    //int monkeyId = int.Parse(lines[i].Replace("Monkey ", null));
    var startingItems = lines[i + 1].Replace("Starting items: ", null).Split(',').Select(x => ulong.Parse(x));
    var operation = lines[i + 2].Replace("Operation: new = old ", null).Trim().Split(' ');
    var testValue = ulong.Parse(lines[i + 3].Replace("Test: divisible by ", null));
    var monkeyOnTrue = int.Parse(lines[i + 4].Replace("If true: throw to monkey ", null));
    var monkeyOnFalse = int.Parse(lines[i + 5].Replace("If false: throw to monkey", null));
    
    monkeys.Add(new()
    {
        currentItems = new Queue<ulong>(startingItems),
        operationType = operation[0],
        operationValue = operation[1],
        testValue = testValue,
        monkeyOnTrue = monkeyOnTrue,
        monkeyOnFalse = monkeyOnFalse
    });
}

var resolver = new Resolver();

Console.WriteLine("Part 1: " + resolver.Resolve(monkeys, true, 20));
Console.WriteLine("Part 2: " + resolver.Resolve(monkeys, false, 10000));

