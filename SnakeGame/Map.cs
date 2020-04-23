using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Map
    {
        private List<List<Point>> _map;

        public Map(int height, int width)
        {
            _map = new List<List<Point>>(height);
            var row = new List<Point>(width);

            int indentToTop = 1;
            int indentToLeft = 2;

            height += indentToTop;
            width += indentToLeft;

            InsertAtRange(row, indentToLeft, width, indentToTop, '#');
            _map.Add(row);
            
            for (int i = indentToTop + 1; i < height - 1; i++)
            {
                row = new List<Point>(width);
                row.Add(new Point(indentToLeft, i, '#', ConsoleColor.Red));
                InsertAtRange(row, indentToLeft + 1, width - 1, i, '\0');
                row.Add(new Point(width - 1, i, '#', ConsoleColor.Red));
                _map.Add(row);
            }

            row = new List<Point>(width);
            InsertAtRange(row, indentToLeft, width, height - 1, '#');
            _map.Add(row);
        }

        private void InsertAtRange(List<Point> line, int start, int end, int height, char sym)
        {
            for (int i = start; i < end; i++)
                line.Add(new Point(i, height, sym, ConsoleColor.Red));
        }

        public bool CheckCollisions(List<Point> snake)
        {
            Point head = snake.Last();
            return _map[head.GetY()][head.GetX()].GetSymbol() == '#';
        }

        public void Show()
        {
            foreach (var row in _map)
                foreach (var col in row)
                    col.Draw();
        }
    }
}
