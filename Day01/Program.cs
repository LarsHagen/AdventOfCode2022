using System;
using System.Collections.Generic;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1");

            LinkedList<int> highestValues = new();
            highestValues.AddFirst(0);
            highestValues.AddFirst(0);
            highestValues.AddFirst(0);

            int currentValue = 0;
            
            foreach (var line in File.ReadLines("Input.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    UpdateHighestValuesList(currentValue, highestValues);
                    currentValue = 0;
                    continue;
                }
                
                currentValue += Int32.Parse(line);
            }
            UpdateHighestValuesList(currentValue, highestValues);
            
            Console.WriteLine("Part 1: " + highestValues.First.Value);

            var top3Total = highestValues.First.Value + 
                            highestValues.First.Next.Value + 
                            highestValues.First.Next.Next.Value;
            
            Console.WriteLine("Part 2: " + top3Total);
        }

        private static void UpdateHighestValuesList(int currentValue, LinkedList<int> highestValues)
        {
            LinkedListNode<int> node = highestValues.First;
            for (int i = 0; i < 3; i++)
            {
                if (currentValue > node.Value)
                {
                    highestValues.AddBefore(node, currentValue);
                    break;
                }

                node = node.Next;
            }
        }
    }
}