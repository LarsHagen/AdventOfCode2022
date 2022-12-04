using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 2");
            
            int part1Score = 0;
            int part2Score = 0;
            
            foreach (var line in File.ReadLines("Input.txt"))
            {
                char player1 = line[0];
                char player2Part1 = XyzToAbc(line[2]);
                char player2Part2 = GetPart2Move(player1, line[2]);
                
                part1Score += TypeScore(player2Part1);
                part1Score += WinScore(player1, player2Part1);
                
                part2Score += TypeScore(player2Part2);
                part2Score += WinScore(player1, player2Part2);
            }
            
            Console.WriteLine("Part 1: " + part1Score);
            Console.WriteLine("Part 2: " + part2Score);
        }

        private static char GetPart2Move(char player1, char strategy)
        {
            //A = Rock
            //B = Paper
            //C = Scissors
            
            if (strategy == 'Y') //Should draw
            {
                return player1;
            }

            bool shouldWin = strategy == 'Z';

            if (player1 == 'A')
                return shouldWin ? 'B' : 'C';
            if (player1 == 'B')
                return shouldWin ? 'C' : 'A';
            if (player1 == 'C')
                return shouldWin ? 'A' : 'B';

            throw new Exception($"This should not happen: {player1}, {strategy}");
        }

        private static char XyzToAbc(char input) => (char)(input - 23);

        private static int TypeScore(char player2Type) => player2Type switch
        {
            'A' => 1,
            'B' => 2,
            'C' => 3,
            _ => throw new Exception($"This should not happen: {player2Type}")
        };
        
        static int WinScore(char player1, char player2)
        {
            //A = Rock
            //B = Paper
            //C = Scissors

            if (player1 == player2)
                return 3;
            
            if (player1 == 'A')
            {
                if (player2 == 'B')
                    return 6;
                if (player2 == 'C')
                    return 0;
            }
            
            if (player1 == 'B')
            {
                if (player2 == 'A')
                    return 0;
                if (player2 == 'C')
                    return 6;
            }
            
            if (player1 == 'C')
            {
                if (player2 == 'A')
                    return 6;
                if (player2 == 'B')
                    return 0;
            }

            throw new Exception($"This should not happen: {player1} vs {player2}");
        }
    }
}