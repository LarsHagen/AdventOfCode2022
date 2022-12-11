using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Console.WriteLine("Day 11");

var lines = File.ReadAllLines("Input.txt");
List<Monkey> monkeys = new();

for (int i = 0; i < lines.Length; i += 7)
{
    //int monkeyId = int.Parse(lines[i].Replace("Monkey ", null));
    var startingItems = lines[i + 1].Replace("Starting items: ", null).Split(',').Select(x => int.Parse(x));
    var operation = lines[i + 2].Replace("Operation: new = old ", null).Trim().Split(' ');
    var testValue = int.Parse(lines[i + 3].Replace("Test: divisible by ", null));
    var monkeyOnTrue = int.Parse(lines[i + 4].Replace("If true: throw to monkey ", null));
    var monkeyOnFalse = int.Parse(lines[i + 5].Replace("If false: throw to monkey", null));
    
    monkeys.Add(new()
    {
        currentItems = new Queue<int>(startingItems),
        operationType = operation[0],
        operationValue = operation[1],
        testValue = testValue,
        monkeyOnTrue = monkeyOnTrue,
        monkeyOnFalse = monkeyOnFalse
    });
}

for (int i = 0; i < 20; i++)
{
    foreach (var monkey in monkeys)
    {
        while (monkey.currentItems.Any())
        {
            var oldValue = monkey.currentItems.Dequeue();
            int modifyValue = monkey.operationValue == "old" ? oldValue : int.Parse(monkey.operationValue);
            int newValue = monkey.operationType == "+" ? oldValue + modifyValue : oldValue * modifyValue;
            newValue /= 3;

            if (newValue % monkey.testValue == 0)
            {
                monkeys[monkey.monkeyOnTrue].currentItems.Enqueue(newValue);
            }
            else
            {
                monkeys[monkey.monkeyOnFalse].currentItems.Enqueue(newValue);
            }
            
            monkey.inspectionCount++;
        }
    }
}

var sorted = monkeys.OrderByDescending(m => m.inspectionCount).ToArray();
int part1 = sorted[0].inspectionCount * sorted[1].inspectionCount;
Console.WriteLine("Part 1: " + part1);

/*
Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3
*/


class Monkey
{
    public Queue<int> currentItems;
    public string operationType;
    public string operationValue;
    public int testValue;
    public int monkeyOnTrue;
    public int monkeyOnFalse;
    public int inspectionCount = 0;
}