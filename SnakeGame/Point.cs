using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Point
    {
       protected int _x;
       protected int _y;
       protected char _sym;
       protected ConsoleColor _color;
        private Dictionary<Direction, Func<int, int>> _operation;

        public Point()
        {
            _operation = new Dictionary<Direction, Func<int, int>>
            {
                { Direction.TOP, (offset) => _y -= offset },
                { Direction.RIGHT, (offset) => _x += offset },
                { Direction.BOTTOM, (offset) => _y += offset },
                { Direction.LEFT, (offset) => _x -= offset },
            };
        }

        public Point(int x, int y, char sym, ConsoleColor color) : this()
        {
            _x = x;
            _y = y;
            _sym = sym;
            _color = color;
        }

        public Point(Point point) : this()
        {
            _x = point._x; 
            _y = point._y;
            _sym = point._sym;
            _color = point._color;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public char GetSymbol()
        {
            return _sym;
        }

        public void Move(int offset, Direction direction)
        {
            _operation[direction](offset);
        }

        public bool CheckCollision(Point otherPoint)
        {
            return _x == otherPoint._x && _y == otherPoint._y;
        }

        public void Draw()
        {
            if (_sym == '\0')
                return;

            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(_sym);
        }

        public void Clear()
        {
            _sym = '\0';

            Console.SetCursorPosition(_x, _y);
            Console.WriteLine('\0');
        }
    }
}
