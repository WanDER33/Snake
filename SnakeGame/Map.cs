using System;
using System.Collections.Generic;
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

            int indentToTop = 2;
            int indentToLeft = 4;

            width += indentToLeft;
            height += indentToTop;

            for (int i = indentToLeft; i < width; i++)
                row.Add(new Point(i, indentToTop, '#', ConsoleColor.Red));

            _map.Add(row);
            
            for (int i = indentToTop + 1; i < height - 1; i++)
            {
                row = new List<Point>(width);
                row.Add(new Point(indentToLeft, i, '#', ConsoleColor.Red));

                for (int j = 1; j < width - 1; j++)
                {
                    row.Add(new Point(j, i, '\0', ConsoleColor.Red));
                }

                row.Add(new Point(width - 1, i, '#', ConsoleColor.Red));
                _map.Add(row);
            }

            row = new List<Point>(width);

            for (int i = indentToLeft; i < width; i++)
                row.Add(new Point(i, height - 1, '#', ConsoleColor.Red));

            _map.Add(row);
        }

        public void Show()
        {
            foreach (var row in _map)
                foreach (var col in row)
                    col.Draw();
        }
    }
}
