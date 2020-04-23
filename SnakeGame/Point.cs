using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Point
    {
        private int _x;
        private int _y;
        private char _sym;
        private ConsoleColor _color;

        public Point(int x, int y, char sym, ConsoleColor color)
        {
            _x = x;
            _y = y;
            _sym = sym;
            _color = color;
        }

        public void Draw()
        {
            if (_sym == '\0')
                return;

            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(_sym);
        }
    }
}
