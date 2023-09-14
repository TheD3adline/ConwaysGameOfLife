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
        const char CHARACTER_DEADL = '.';

        public Cell[,] Fields { get; private set; }
        public int Generation { get; private set; }

        public Board(int width, int height) 
        {
            Fields = new Cell[width, height];
            Generation = 1;

            for (int y = 0; y < Fields.GetLength(1); y++)
            {
                for (int x = 0; x < Fields.GetLength(0); x++)
                {
                    Fields[x, y] = new Cell(false);
                }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (true)
            {
                //Draw();
                //Update();
                Generation += 1;
                Thread.Sleep(100);
            }
        }
    }
}