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
            
            foreach (var line in File.ReadLines("Input.txt"))
            {
                char player1 = line[0];
                char player2 = line[2];

                part1Score += TypeScore(player2);
                part1Score += WinScore(player1, player2);
            }
            
            Console.WriteLine("Part 1: " + part1Score);
        }

        private static int TypeScore(char player2Type) => player2Type switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new Exception($"This should not happen: {player2Type}")
        };
        
        static int WinScore(char player1, char player2)
        {
            //A/X = Rock
            //B/Y = Paper
            //C/Z = Scissors
            
            if (player1 == 'A')
            {
                if (player2 == 'X')
                    return 3;
                if (player2 == 'Y')
                    return 6;
                if (player2 == 'Z')
                    return 0;
            }
            
            if (player1 == 'B')
            {
                if (player2 == 'X')
                    return 0;
                if (player2 == 'Y')
                    return 3;
                if (player2 == 'Z')
                    return 6;
            }
            
            if (player1 == 'C')
            {
                if (player2 == 'X')
                    return 6;
                if (player2 == 'Y')
                    return 0;
                if (player2 == 'Z')
                    return 3;
            }

            throw new Exception($"This should not happen: {player1} vs {player2}");
        }
    }
}