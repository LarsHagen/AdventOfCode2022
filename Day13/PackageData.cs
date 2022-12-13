using System;
using System.Collections.Generic;

namespace Day13
{
    public class PackageData
    {
        public string Input { get; private set; }
        public List<PackageData> children = new();
        public int? value;

        public PackageData(string input)
        {
            Input = input;
            Parse(input);
        }

        public enum Result
        {
            Correct,
            Wrong,
            Equal
        };
        
        private void Parse(string input)
        {
            if (input[0] == '[')
            {
                input = input.Substring(1, input.Length - 2);
                if (input.Length == 0)
                    return;
                
                List<string> subStrings = new List<string>();
                string s = "";
                int level = 0;
                
                for (int i = 0; i < input.Length; i++)
                {
                    var c = input[i];

                    if (c == ',' && level == 0)
                    {
                        subStrings.Add(s);
                        s = "";
                        continue;
                    }
                    
                    if (c == '[')
                    {
                        level++;
                    }

                    if (c == ']')
                    {
                        level--;
                    }

                    s += c;
                }
                subStrings.Add(s);
                
                foreach (var sub in subStrings)
                {
                    children.Add(new PackageData(sub));
                }

                return;
            }

            value = int.Parse(input);
        }

        private Result Compare(PackageData left, PackageData right)
        {
            //Console.WriteLine($"{left._input} vs {right._input}");
            
            //If both are a value, compare the values
            if (left.value != null && right.value != null)
            {
                if (left.value < right.value)
                    return Result.Correct;
                if (left.value > right.value)
                    return Result.Wrong;
                return Result.Equal;
            }

            //If both are lists then compare each element in the list
            if (left.value == null && right.value == null)
            {
                var min = Math.Min(left.children.Count, right.children.Count);
                for (int i = 0; i < min; i++)
                {
                    var r = Compare(left.children[i], right.children[i]);
                    if (r == Result.Correct || r == Result.Wrong)
                        return r;
                }

                if (left.children.Count == right.children.Count)
                    return Result.Equal;

                if (left.children.Count > right.children.Count)
                    return Result.Wrong; //Right ran out
                return Result.Correct; //Left ran out
            }

            //If left is value and right is list, convert left to list and compare
            if (left.value != null && right.value == null)
            {
                var leftAsArray = new PackageData($"[{left.value}]");
                return Compare(leftAsArray, right);
            }
            
            //If right is value and left is list, convert right to list and compare
            if (right.value != null && left.value == null)
            {
                var rightAsArray = new PackageData($"[{right.value}]");
                return Compare(left, rightAsArray);
            }

            //Something went wrong here!
            return Result.Equal;
        }

        public bool CompareOrder(PackageData other)
        {
            var result = Compare(this, other);
            
            if (result == Result.Correct)
                return true;
            if (result == Result.Wrong)
                return false;

            throw new Exception("Result was equal!");
        }
    }
}