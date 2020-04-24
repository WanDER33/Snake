using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);

            Console.Write("Press enter to start.. ");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();

                var map = new Map(23, 78);
                Point p = new Point(35, 10, '%', ConsoleColor.Green);
                var snake = new Snake(p, 4, Direction.RIGHT, map);

                Food food = new Food(map, '$');

                map.Show();
                snake.Show();
                food.Show();

                while (snake.IsAlive)
                {
                    Console.SetCursorPosition(1, 0);
                    Console.WriteLine($"Score: {map.Score}");

                    snake.Controll();
                    
                    if (snake.Eat(food))
                    {
                        food = new Food(map, '$');
                        food.Show();

                        map.Score += 10;
                    }
                    else
                    {
                        snake.Move();
                    }
                    
                    Thread.Sleep(200);
                }

                Console.SetCursorPosition(0, 25);
                Console.ResetColor();

                Console.Write("Press enter to play again.. (Esc to quit)");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
