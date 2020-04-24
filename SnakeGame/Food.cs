using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Food : Point
    {
        private Map _map;
    
        public Food(Map map, char sym) : base (map.GeneratePoint(sym))
        {
            _map = map;
        }

        public bool IsEaten(List<Point> snake)
        {
            Point head = snake.Last();
            
            if (_map.CheckCollisions(head))
            {
                _map.Score += 10;
                return true;
            }
            
            return false;
        }

        public void Show()
        {
            base.Draw();
        }
    }
}
