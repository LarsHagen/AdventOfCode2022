using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Resolver
    {
        public ulong Resolve(List<Monkey> monkeys, bool divideWorry, int iterations)
        {
            ulong shared = 1;
            foreach (var monkey in monkeys)
            {
                shared *= monkey.testValue;
            }
            
            
            for (int i = 0; i < iterations; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.currentItems.Any())
                    {
                        var oldValue = monkey.currentItems.Dequeue();
                        ulong modifyValue = monkey.operationValue == "old"
                            ? oldValue
                            : ulong.Parse(monkey.operationValue);
                        ulong newValue = monkey.operationType == "+" ? oldValue + modifyValue : oldValue * modifyValue;

                        if (divideWorry)
                            newValue /= 3;
                        else
                            newValue %= shared;

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
            return sorted[0].inspectionCount * sorted[1].inspectionCount;
        }
    }
}