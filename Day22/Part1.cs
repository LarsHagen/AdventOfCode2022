using System;

namespace Day22
{
    public static class Part1
    {
        public static int Run(char[,] map, int mapWidth, int mapHeight, int positionX, int positionY, int xDir,
            int yDir, string instructions)
        {

            char FindValid(ref int moveToX, ref int moveToY)
            {
                if (moveToX >= mapWidth)
                    moveToX = 0;
                if (moveToX < 0)
                    moveToX = mapWidth - 1;
                if (moveToY >= mapHeight)
                    moveToY = 0;
                if (moveToY < 0)
                    moveToY = mapHeight - 1;

                return map[moveToX, moveToY];
            }


            while (instructions.Length > 0)
            {
                var indexOfNextTurn = instructions.IndexOfAny(new[] {'L', 'R'});
                int move;
                char nextTurn;
                if (indexOfNextTurn == -1)
                {
                    move = int.Parse(instructions);
                    nextTurn = ' ';
                    instructions = "";
                }
                else
                {
                    move = int.Parse(instructions.Substring(0, indexOfNextTurn));
                    nextTurn = instructions[indexOfNextTurn];
                    instructions = instructions.Remove(0, indexOfNextTurn + 1);
                }


                for (int i = 0; i < move; i++)
                {
                    int moveToX = positionX;
                    int moveToY = positionY;
                    char mapSpot;
                    do
                    {
                        moveToX += xDir;
                        moveToY += yDir;
                        mapSpot = FindValid(ref moveToX, ref moveToY);
                    } while (mapSpot == ' ');

                    if (mapSpot == '#')
                        break;
                    positionX = moveToX;
                    positionY = moveToY;
                }

                Console.WriteLine(move + ": " + nextTurn);
                Console.WriteLine(positionX + ", " + positionY);

                if (nextTurn == ' ')
                {
                    Console.WriteLine("Done");
                }

                if (nextTurn == 'L')
                {
                    if (xDir == 1)
                    {
                        yDir = -1;
                        xDir = 0;
                    }
                    else if (xDir == -1)
                    {
                        yDir = 1;
                        xDir = 0;
                    }
                    else if (yDir == -1)
                    {
                        xDir = -1;
                        yDir = 0;
                    }
                    else
                    {
                        xDir = 1;
                        yDir = 0;
                    }
                }

                if (nextTurn == 'R')
                {
                    if (xDir == 1)
                    {
                        yDir = 1;
                        xDir = 0;
                    }
                    else if (xDir == -1)
                    {
                        yDir = -1;
                        xDir = 0;
                    }
                    else if (yDir == -1)
                    {
                        xDir = 1;
                        yDir = 0;
                    }
                    else
                    {
                        xDir = -1;
                        yDir = 0;
                    }
                }
            }

            int row = positionY + 1;
            int column = positionX + 1;
            int facing;
            if (xDir == 1)
                facing = 0;
            else if (yDir == 1)
                facing = 1;
            else if (xDir == -1)
                facing = 2;
            else
                facing = 3;


            return row * 1000 + column * 4 + facing;
        }
    }
}