using System;
using System.Collections.Generic;

namespace Day21
{
    public static class Part2
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
            
            var root = monkeysToCalculate["root"];
            monkeysToCalculate.Remove("root");
            calculatedMonkeys.Remove("humn");

            bool stuck = false;
            
            while (!stuck)
            {
                stuck = true;
                foreach (var monkey in monkeysToCalculate)
                {
                    if (calculatedMonkeys.ContainsKey(monkey.Value.A) &&
                        calculatedMonkeys.ContainsKey(monkey.Value.B))
                    {
                        stuck = false;
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

            long target;
            if (calculatedMonkeys.ContainsKey(root.A))
            {
                target = calculatedMonkeys[root.A];
                calculatedMonkeys.Add(root.B, target);
            }
            else
            {
                target = calculatedMonkeys[root.B];
                calculatedMonkeys.Add(root.A, target);
            }

            while (monkeysToCalculate.Count > 0)
            {
                foreach (var monkey in monkeysToCalculate)
                {
                    if (calculatedMonkeys.ContainsKey(monkey.Key))
                    {
                        var shouldEqual = calculatedMonkeys[monkey.Key];
                        if (calculatedMonkeys.ContainsKey(monkey.Value.A))
                        {
                            calculatedMonkeys.Add(monkey.Value.B, 
                                monkey.Value.GetB(shouldEqual, calculatedMonkeys[monkey.Value.A]));
                            monkeysToCalculate.Remove(monkey.Key);
                        }
                        else if (calculatedMonkeys.ContainsKey(monkey.Value.B))
                        {
                            calculatedMonkeys.Add(monkey.Value.A, 
                                monkey.Value.GetA(shouldEqual, calculatedMonkeys[monkey.Value.B]));
                            monkeysToCalculate.Remove(monkey.Key);
                        }
                    }
                }
            }

            return calculatedMonkeys["humn"];
        }
    }
}