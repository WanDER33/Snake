using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Map
    {
        public int Score { get; set; }

        private List<List<Point>> _map;
        private int indentToTop = 1;
        private int indentToLeft = 2;
        private int _height;
        private int _width;

        public Map(int height, int width)
        {
            _map = new List<List<Point>>(_height);
            var row = new List<Point>(_width);

            _height = height;
            _width = width;

            _height += indentToTop;
            _width += indentToLeft;

            InsertAtRange(row, indentToLeft, _width, indentToTop, '#');
            _map.Add(row);
            
            for (int i = indentToTop + 1; i < _height - 1; i++)
            {
                row = new List<Point>(_width);
                row.Add(new Point(indentToLeft, i, '#', ConsoleColor.Red));
                InsertAtRange(row, indentToLeft + 1, _width - 1, i, '\0');
                row.Add(new Point(_width - 1, i, '#', ConsoleColor.Red));
                _map.Add(row);
            }

            row = new List<Point>(_width);
            InsertAtRange(row, indentToLeft, _width, _height - 1, '#');
            _map.Add(row);
        }

        private void InsertAtRange(List<Point> line, int start, int end, int height, char sym)
        {
            for (int i = start; i < end; i++)
                line.Add(new Point(i, height, sym, ConsoleColor.Red));
        }

        public bool CheckCollisions(Point head)
        {
            return _map[head.GetY() - indentToTop][head.GetX() - indentToLeft].GetSymbol() != '\0';
        }

        public Point GeneratePoint(char sym)
        {
            var random = new Random();
         
            int x = random.Next(indentToLeft + 1, _width - indentToLeft);
            int y = random.Next(indentToTop + 1, _height - indentToTop);

            while(_map[y][x].GetSymbol() != '\0')
            {
                x = random.Next(indentToLeft + 1, _width - indentToLeft);
                y = random.Next(indentToTop + 1, _height - indentToTop);
            }

            Point point = new Point(x, y, sym, ConsoleColor.DarkYellow);
            Place(point);

            return point;
        }

        public void Place(Point point)
        {
            _map[point.GetY() - indentToTop][point.GetX() - indentToLeft] = point;
        }

        public void Remove(Point point)
        {
            point.Clear();
        }

        public void Show()
        {
            foreach (var row in _map)
                foreach (var col in row)
                    col.Draw();
        }
    }
}
