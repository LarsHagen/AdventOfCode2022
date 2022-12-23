using System;

namespace Day22
{
    public static class Part2
    {
        private static bool CrossedSide = false;
        
        public static int Run(char[,] map, int mapWidth, int mapHeight, int positionX, int positionY, int xDir,
            int yDir, string instructions)
        {
            //int sideSize = mapHeight / 3; //Example input
            int sideSize = mapHeight / 4; //Real input
            
            char FindValid(ref int moveToX, ref int moveToY)
            {
                CrossedSide = false;
                int side = FindCurrentSide(positionX, positionY, sideSize);

                if (side == 1)
                {
                    if (moveToY < 0) //Move out of top into 6 from left
                    {
                        CrossedSide = true;
                        yDir = 0;
                        xDir = 1;
                        moveToY = (moveToX - sideSize) + sideSize * 3;
                        moveToX = 0;
                    }
                    else if (xDir == -1 && map[moveToX, moveToY] == ' ') //Move out to left into 5 from left
                    {
                        CrossedSide = true;
                        xDir = 1;
                        yDir = 0;
                        moveToY = (sideSize * 3 - 1) - moveToY;
                        moveToX = 0;
                    }
                }

                if (side == 2)
                {
                    if (moveToY < 0) //Moved out of top into 6 from bottom
                    {
                        CrossedSide = true;
                        xDir = 0;
                        yDir = -1;

                        moveToX = moveToX - sideSize * 2;
                        moveToY = mapHeight - 1;
                    }
                    else if (moveToX >= mapWidth) //Moved out right into 4 from right
                    {
                        CrossedSide = true;
                        xDir = -1;

                        moveToY = sideSize * 3 - moveToY - 1;
                        moveToX = sideSize * 2 - 1;
                    }
                    else if (yDir == 1 && map[moveToX, moveToY] == ' ') //Moved down into 3 from right
                    {
                        CrossedSide = true;
                        yDir = 0;
                        xDir = -1;

                        moveToY = sideSize + (moveToX - sideSize * 2);
                        moveToX = sideSize * 2 - 1;
                    }
                }

                if (side == 3)
                {
                    if (xDir == -1 && map[moveToX, moveToY] == ' ') //Moved left into 5 from top
                    {
                        CrossedSide = true;
                        yDir = 1;
                        xDir = 0;

                        moveToX = moveToY - sideSize;
                        moveToY = sideSize * 2;
                    }
                    else if (xDir == 1 && map[moveToX, moveToY] == ' ') //Moved left into 2 from bottom
                    {
                        CrossedSide = true;
                        yDir = -1;
                        xDir = 0;

                        moveToX = sideSize * 2 + (moveToY - sideSize);
                        moveToY = sideSize - 1;
                    }
                }

                if (side == 4)
                {
                    if (xDir == 1 && map[moveToX, moveToY] == ' ')//Moved right into 2 from right
                    {
                        CrossedSide = true;
                        xDir = -1;
                        yDir = 0;

                        moveToY = (sideSize * 3 - 1) - moveToY;
                        moveToX = sideSize * 3 - 1;
                    }
                    else if (yDir == 1 && map[moveToX, moveToY] == ' ') //Move down into 6 from right
                    {
                        CrossedSide = true;
                        moveToY = sideSize * 3 + (moveToX - sideSize);
                        moveToX = sideSize - 1;
                    }
                }

                if (side == 5)
                {
                    if (moveToX < 0) //Moved left into 1 from left
                    {
                        CrossedSide = true;
                        yDir = 0;
                        xDir = 1;

                        moveToY = (sideSize * 3 - 1) - moveToY;
                        moveToX = sideSize;
                    }
                    else if (yDir == -1 && map[moveToX, moveToY] == ' ') //Moved up into 3 from left
                    {
                        CrossedSide = true;
                        xDir = 1;
                        yDir = 0;

                        moveToY = sideSize + moveToX;
                        moveToX = sideSize;
                    }
                }

                if (side == 6)
                {
                    if (moveToY >= mapHeight) //Moved down into 2 from top 
                    {
                        CrossedSide = true;
                        yDir = 1;
                        xDir = 0;
                        moveToY = 0;
                        moveToX = sideSize * 2 + moveToX;
                    }
                    else if (moveToX < 0) //Moved left into 1 from top
                    {
                        CrossedSide = true;
                        yDir = 1;
                        xDir = 0;
                        moveToX = (moveToY - sideSize * 3) + sideSize;
                        moveToY = 0;
                    }
                    else if (xDir == 1 && map[moveToX, moveToY] == ' ') //Moved right into 4 from bottom
                    {
                        CrossedSide = true;
                        xDir = 0;
                        yDir = -1;

                        moveToX = sideSize + (moveToY - sideSize * 3);
                        moveToY = sideSize * 3 - 1;
                    }
                }
                
                return map[moveToX, moveToY];
            }
            
            char FindValidExample(ref int moveToX, ref int moveToY)
            {
                int side = FindCurrentSideExample(positionX, positionY, sideSize);

                if (side == 1)
                {
                    if (moveToY < 0) //Move out of top into 2
                    {
                        yDir = 1;
                        moveToX = sideSize - (moveToX - sideSize * 2);
                        moveToY = sideSize;
                    }
                    else if (xDir == 1 && map[moveToX, moveToY] == ' ') //Move out to right into 6
                    {
                        xDir = -1;
                        moveToX = mapWidth - 1;
                        moveToY = mapHeight - moveToY - 1;
                    }
                    else if (xDir == -1 && map[moveToX, moveToY] == ' ') //Move out to left into 3
                    {
                        xDir = 0;
                        yDir = -1;
                        moveToX = sideSize + moveToY;
                        moveToY = sideSize;
                    }
                }

                if (side == 2)
                {
                    if (moveToX < 0) //Moved out to left into 6
                    {
                        xDir = 0;
                        yDir = 1;

                        moveToX = sideSize * 3 + (moveToY - sideSize);
                        moveToY = mapHeight - 1;
                    }
                    else if (yDir == -1 && map[moveToX, moveToY] == ' ') //Moved up into 1
                    {
                        yDir = 1;
                        moveToX = sideSize * 3 - moveToX;
                        moveToY = 0;
                    }
                    else if (yDir == 1 && map[moveToX, moveToY] == ' ') //Moved down into 5
                    {
                        yDir = -1;
                        moveToX = sideSize * 3 - moveToX;
                        moveToY = mapHeight - 1;
                    }
                }

                if (side == 3)
                {
                    if (yDir == -1 && map[moveToX, moveToY] == ' ') //Moved up into 1
                    {
                        yDir = 0;
                        xDir = 1;
                        moveToY = moveToX - sideSize;
                        moveToX = sideSize * 2;
                    }
                    else if (yDir == 1 && map[moveToX, moveToY] == ' ') //Moved down into 5
                    {
                        yDir = 0;
                        xDir = 1;
                        moveToY = sideSize * 3 - (moveToX - sideSize) - 1;
                        moveToX = sideSize * 2;
                    }
                }

                if (side == 4)
                {
                    if (xDir == 1 && map[moveToX, moveToY] == ' ')//Moved right into 6
                    {
                        xDir = 0;
                        yDir = 1;
                        moveToX = mapWidth - (moveToY - sideSize) - 1;
                        moveToY = sideSize * 2;
                    }
                }

                if (side == 5)
                {
                    if (moveToY >= mapHeight) //Moved down into 2
                    {
                        yDir = -1;
                        xDir = 0;

                        moveToX = sideSize - (moveToX - sideSize * 2) - 1;
                        moveToY = sideSize * 2 - 1;
                    }
                    else if (xDir == -1 && map[moveToX, moveToY] == ' ') //Moved left into 3
                    {
                        xDir = 0;
                        yDir = -1;

                        moveToX = sideSize * 2 - (mapHeight - moveToY);
                        moveToY = sideSize * 2;
                    }
                }

                if (side == 6)
                {
                    if (moveToY >= mapHeight) //Moved down into 2
                    {
                        yDir = 0;
                        xDir = 1;
                        moveToY = sideSize + (mapHeight - moveToY);
                        moveToX = 0;
                    }

                    if (moveToX >= mapWidth) //Moved right into 1
                    {
                        xDir = -1;
                        moveToY = moveToY - sideSize * 2;
                        moveToX = sideSize * 3 - 1;
                    }

                    if (yDir == -1 && map[moveToX, moveToY] == ' ') //Moved up into 4
                    {
                        xDir = -1;
                        yDir = 0;
                        moveToY = sideSize * 2 - (moveToX - sideSize * 3);
                        moveToX = sideSize * 3 - 1;
                    }
                }
                
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

                Console.WriteLine(move + ": " + nextTurn);
                
                for (int i = 0; i < move; i++)
                {
                    int moveToX = positionX + xDir;
                    int moveToY = positionY + yDir;
                    char mapSpot;
                    int oldDirX = xDir;
                    int oldDirY = yDir;
                    
                    mapSpot = FindValid(ref moveToX, ref moveToY);

                    if (mapSpot == ' ')
                        throw new Exception("What is going on here?");
                    
                    if (mapSpot == '#')
                    {
                        xDir = oldDirX;
                        yDir = oldDirY;
                        moveToX = positionX;
                        moveToY = positionY;
                        break;
                    }

                    if (CrossedSide)
                        PrintMap(map, mapWidth, mapHeight, positionX, positionY, oldDirX, oldDirY, moveToX, moveToY, xDir, yDir);
                    
                    positionX = moveToX;
                    positionY = moveToY;
                }

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

                //PrintMap(map, mapWidth, mapHeight, positionX, positionY, xDir, yDir);
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

        private static void PrintMap(char[,] map, int mapWidth, int mapHeight, int positionX, int positionY, int xDir, int yDir, int newPositionX, int newPositionY, int newDirX, int newDirY)
        {
            return;
            char dir = xDir == 1 ? '>' : xDir == -1 ? '<' : yDir == 1 ? 'v' : '^';
            char newDir = newDirX == 1 ? '>' : newDirX == -1 ? '<' : newDirY == 1 ? 'v' : '^';
            for (int y = 0; y < mapHeight; y++)
            {
                string line = "";
                for (int x = 0; x < mapWidth; x++)
                {
                    if (x == positionX && y == positionY)
                        line += dir;
                    else if (x == newPositionX && y == newPositionY)
                        line += newDir;
                    else
                        line += map[x, y];
                }

                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        private static int FindCurrentSideExample(int positionX, int positionY, int sideSize)
        {
            int side;
            if (positionY < sideSize)
            {
                side = 1;
            }
            else if (positionY < sideSize * 2)
            {
                if (positionX < sideSize)
                {
                    side = 2;
                }
                else if (positionX < sideSize * 2)
                {
                    side = 3;
                }
                else
                {
                    side = 4;
                }
            }
            else
            {
                if (positionX < sideSize * 3)
                {
                    side = 5;
                }
                else
                {
                    side = 6;
                }
            }

            return side;
        }
        
        private static int FindCurrentSide(int positionX, int positionY, int sideSize)
        {
            int side;
            if (positionY < sideSize)
            {
                if (positionX < sideSize * 2)
                {
                    side = 1;
                }
                else
                {
                    side = 2;
                } 
            }
            else if (positionY < sideSize * 2)
            {
                side = 3;
            }
            else if (positionY < sideSize * 3)
            {
                if (positionX < sideSize)
                {
                    side = 5;
                }
                else
                {
                    side = 4;
                }
            }
            else
            {
                side = 6;
            }

            return side;
        }
    }
}