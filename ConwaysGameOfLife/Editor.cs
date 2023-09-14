using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    internal class Editor
    {
        const char CHARACTER_ALIVE = '#';
        const char CHARACTER_DEAD = 'O';
        public bool[,] Fields {  get; set; }
        public int CursorX { get; set; }
        public int CursorY { get; set; }

        public Editor(int width, int height)
        {
            Fields = new bool[width, height];
            CursorX = 0;
            CursorY = 0;

            for (int y = 0; y < Fields.GetLength(1); y++)
            {
                for (int x = 0; x < Fields.GetLength(0); x++)
                {
                    Fields[x, y] = false;
                }
            }
        }

        public void StartEditor()
        {
            while (true)
            {
                Draw();
                bool end = TakeInput();

                if (end)
                    break;
            }

            Board board = new Board(Fields);
            Console.Clear();
            board.Run();
        }

        private bool TakeInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {   
                if (CursorY > 0)
                    CursorY -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (CursorY < Fields.GetLength(1) - 1)
                    CursorY += 1;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (CursorX > 0)
                    CursorX -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (CursorX < Fields.GetLength(0) - 1)
                    CursorX += 1;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
                Fields[CursorX, CursorY] = !Fields[CursorX, CursorY];
            else if (keyInfo.Key == ConsoleKey.Enter)
                return true;

            return false;
        }

        private void Draw()
        {
            Console.Clear();

            for (int y = 0; y < Fields.GetLength(1); y++)
            {
                for (int x = 0; x < Fields.GetLength(0); x++)
                {
                    if (x == CursorX && y == CursorY)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (Fields[x, y] == false)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    if (Fields[x, y] == false)
                        Console.Write(CHARACTER_DEAD);
                    else
                        Console.Write(CHARACTER_ALIVE);

                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
