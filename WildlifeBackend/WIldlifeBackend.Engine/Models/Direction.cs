using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeBackend.Engine.Models
{
    public class Direction
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Direction(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
