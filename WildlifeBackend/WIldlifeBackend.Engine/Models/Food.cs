using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeBackend.Engine.Models
{
    public class Food
    {
        public Position Position { get; set; }
        public double Mass { get; set; }

        public Food(Position position, double mass)
        {
            Position = position;
            Mass = mass;
        }

    }
}
