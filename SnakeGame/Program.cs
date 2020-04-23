using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 3, '*', ConsoleColor.Red);
            p1.Draw();

            Point p2 = new Point(4, 5, '#', ConsoleColor.Green);
            p2.Draw();

            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
