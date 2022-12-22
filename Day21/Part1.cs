using System;
using System.Collections.Generic;

namespace Day21
{
    public static class Part1
    {
        public static long Run(IEnumerable<string> lines)
        {
            Dictionary<string,long> calculatedMonkeys = new();
            Dictionary<string, IExpression> monkeysToCalculate = new();
            
            foreach (var line in lines)
            {
                var split = line.Split(":");
                string monkeyName = split[0].Trim();
            
                if (split[1].Contains("+"))
                {
                    monkeysToCalculate.Add(monkeyName, new Add()
                    {
                        A = split[1].Split("+")[0].Trim(),
                        B = split[1].Split("+")[1].Trim()
                    });
                }
                else if (split[1].Contains("-"))
                {
                    monkeysToCalculate.Add(monkeyName, new Substract()
                    {
                        A = split[1].Split("-")[0].Trim(),
                        B = split[1].Split("-")[1].Trim()
                    });
                }
                else if (split[1].Contains("*"))
                {
                    monkeysToCalculate.Add(monkeyName, new Multiply()
                    {
                        A = split[1].Split("*")[0].Trim(),
                        B = split[1].Split("*")[1].Trim()
                    });
                }
                else if (split[1].Contains("/"))
                {
                    monkeysToCalculate.Add(monkeyName, new Divide()
                    {
                        A = split[1].Split("/")[0].Trim(),
                        B = split[1].Split("/")[1].Trim()
                    });
                }
                else
                {
                    calculatedMonkeys.Add(monkeyName, long.Parse(split[1]));
                }
            }
            
            while (monkeysToCalculate.Count > 0)
            {
                foreach (var monkey in monkeysToCalculate)
                {
                    if (calculatedMonkeys.ContainsKey(monkey.Value.A) &&
                        calculatedMonkeys.ContainsKey(monkey.Value.B))
                    {
                        calculatedMonkeys.Add(monkey.Key, monkey.Value.Eval(
                            calculatedMonkeys[monkey.Value.A],
                            calculatedMonkeys[monkey.Value.B]));
                    }
                }
            
                foreach (var key in calculatedMonkeys.Keys)
                {
                    if (monkeysToCalculate.ContainsKey(key))
                        monkeysToCalculate.Remove(key);
                }
            }

            return calculatedMonkeys["root"];
        }
    }
}