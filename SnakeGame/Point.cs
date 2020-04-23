using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Point
    {
        private int x;
        private int y;
        private char sym;
        private ConsoleColor color;

        public Point(int x, int y, char sym, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }
    }
}
