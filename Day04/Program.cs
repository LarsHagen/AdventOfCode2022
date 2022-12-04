using System;
using System.IO;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 4");

            int fullyContained = 0;
            
            foreach (var line in File.ReadLines("Input.txt"))
            {
                var pairs = line.Split(',');
                var segments1 = pairs[0].Split('-');
                var segments2 = pairs[1].Split('-');
                
                var segments1Start = int.Parse(segments1[0]);
                var segments1End = int.Parse(segments1[1]);;
                var segments2Start = int.Parse(segments2[0]);;
                var segments2End = int.Parse(segments2[1]);;

                if (segments1Start <= segments2Start && segments1End >= segments2End)
                {
                    fullyContained++;
                }
                else if (segments2Start <= segments1Start && segments2End >= segments1End)
                {
                    fullyContained++;
                }
            }
            
            Console.WriteLine("Part 1: " + fullyContained);
        }
    }
}