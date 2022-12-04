using System;
using System.IO;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 3");

            int part1Score = 0;

            var readLines = File.ReadLines("Input.txt").ToList();

            foreach (var line in readLines)
            {
                var compartment1 = line.Substring(0, line.Length / 2).ToList();
                var compartment2 = line.Substring(line.Length / 2, line.Length / 2).ToList();

                var shared = compartment1.First(x => compartment2.Contains(x));
                Console.WriteLine("Shared = " + shared + ". Value: " + GetScore(shared));
                part1Score += GetScore(shared);
            }

            Console.WriteLine("Part 1: " + part1Score);

            int part2Score = 0;
            
            for (int i = 0; i < readLines.Count(); i += 3)
            {
                var ruckSack1 = readLines[i].ToList();
                var ruckSack2 = readLines[i + 1].ToList();
                var ruckSack3 = readLines[i + 2].ToList();

                var shared = ruckSack1.First(x => ruckSack2.Contains(x) && ruckSack3.Contains(x));
                Console.WriteLine("Shared = " + shared + ". Value: " + GetScore(shared));
                part2Score += GetScore(shared);
            }
            
            Console.WriteLine("Part 2: " + part2Score);
        }

        private static int GetScore(char input)
        {
            if (input >= 'a')
                return input - 96;
            return input - 38;
        }
    }
}