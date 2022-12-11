using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Resolver
    {
        public ulong Resolve(List<Monkey> monkeys)
        {
            for (int i = 0; i < 20; i++)
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
            return sorted[0].inspectionCount * sorted[1].inspectionCount;
        }
    }
}