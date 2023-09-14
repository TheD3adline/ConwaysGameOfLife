using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    internal class Board
    {
        const char CHARACTER_ALIVE = '#';
        const char CHARACTER_DEAD = '.';

        public Cell[,] Fields { get; private set; }
        public int Generation { get; private set; }

        public Board(int width, int height) 
        {
            Fields = new Cell[width, height];
            Generation = 1;

            Random rnd = new Random();
            for (int y = 0; y < Fields.GetLength(1); y++)
            {
                for (int x = 0; x < Fields.GetLength(0); x++)
                {
                    int num = rnd.Next(0, 2);
                    if (num == 0)
                        Fields[x, y] = new Cell(false);
                    else
                        Fields[x, y] = new Cell(true);
                }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (true)
            {
                Draw();
                Update();
                Generation += 1;
                Thread.Sleep(100);
            }
        }

        private void Draw()
        {
            if (Generation == 1) 
            {
                for (int y = 0; y < Fields.GetLength(1); y++)
                {
                    for (int x = 0; x < Fields.GetLength(0); x++)
                    {
                        if (Fields[x, y].Alive)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(CHARACTER_ALIVE);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(CHARACTER_DEAD);
                            Console.ResetColor();
                        }

                        Console.Write(" ");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                for (int y = 0; y < Fields.GetLength(1); y++)
                {
                    for (int x = 0; x < Fields.GetLength(0); x++)
                    {
                        if (Fields[x, y].LastGenerationStatus != Fields[x, y].Alive)
                        {
                            Console.SetCursorPosition((x * 2) + 1, y);
                            Console.Write("\b \b");

                            if (Fields[x, y].Alive)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(CHARACTER_ALIVE);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(CHARACTER_DEAD);
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
        }

        private void Update()
        {
            for (int y = 0; y < Fields.GetLength(1); y++)
            {
                for (int x = 0; x < Fields.GetLength(0); x++)
                {
                    CountAliveNeighbourCells(x, y);
                    Fields[x, y].CheckNextCellStatus();
                }
            }

            foreach(Cell cell in Fields)
            {
                cell.Update();
            }
        }

        private void CountAliveNeighbourCells(int xPos, int yPos)
        {
            int count = 0;

            for (int y = yPos - 1; y < yPos + 2; y++)
            {
                for (int x = xPos - 1; x < xPos + 2; x++)
                {
                    if (x == xPos && y == yPos)
                        continue;
                    if ((x >= 0 && x < Fields.GetLength(0)) && (y >= 0 && y < Fields.GetLength(1))) 
                    {
                        if (Fields[x, y].Alive)
                        {
                            count++;
                        }
                    }
                }
            }

            Fields[xPos, yPos].AmountOfNeighbours = count;
        }
    }
}