using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(20, 40);

            map.Show();

            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
