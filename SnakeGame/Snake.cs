using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public bool IsAlive { get; set; }
        private List<Point> _snake;
        private Direction _direction;
        private Map _map;

        public Snake(Point tail, int length, Direction direction, Map map)
        {
            _snake = new List<Point>(length);
            _direction = direction;
            _map = map;

            for (int i = 0; i < length; i++)
            {
                Point point = new Point(tail);
                point.Move(i, direction);
                _snake.Add(point);
            }

            IsAlive = true;
        }

        public void Move()
        {
            Point tail = _snake.First();
            _snake.Remove(tail);

            Point head = GetNextPoint();
            _snake.Add(head);

            if (_map.CheckCollisions(head))
                IsAlive = false;

            _map.Remove(tail);
            tail.Clear();

            _map.Place(head);
            head.Draw();
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();

            if (head.CheckCollision(food))
            {
                _snake.Add(head);
                _map.Place(head);

                head.Draw();
                return true;
            }

            return false;
        }

        private Point GetNextPoint()
        {
            Point lastHead = _snake.Last();
            Point newHead = new Point(lastHead);
            newHead.Move(1, _direction);

            return newHead;
        }

        public void Controll()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            ChangeDirection(Direction.TOP);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            ChangeDirection(Direction.RIGHT);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            ChangeDirection(Direction.BOTTOM);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            ChangeDirection(Direction.LEFT);
                            break;
                        }
                }
            }

        }

        private void ChangeDirection(Direction direction)
        {
            if (_direction == direction)
                return;

            if (_direction == Direction.TOP && direction == Direction.BOTTOM)
                return;

            if (_direction == Direction.RIGHT && direction == Direction.LEFT)
                return;

            if (_direction == Direction.BOTTOM && direction == Direction.TOP)
                return;

            if (_direction == Direction.LEFT && direction == Direction.RIGHT)
                return;

            _direction = direction;
        }

        public void Show()
        {
            foreach (var el in _snake)
                el.Draw();
        }
    }
}
