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
            
            var map = new Map(23, 78);

            Point p = new Point(35, 10, '+', ConsoleColor.Green);
            var snake = new Snake(p, 4, Direction.RIGHT, map);
            
            map.Show();
            snake.Show();

            while (snake.IsAlive)
            {
                snake.Controll();
                snake.Move();
                Thread.Sleep(100);
            }

            Console.SetCursorPosition(0, 23);
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
