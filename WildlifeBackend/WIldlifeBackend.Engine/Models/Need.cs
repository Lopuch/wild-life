using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIldlifeBackend.Engine.Models
{
    internal class Need
    {
        public enum NeedTypes
        {
            Obey,
            Follow,
            Eat,
            Rest,
            Reproduce,
        }

        public NeedTypes Type { get; set; }
        public double Satisfaction { get; set; }
        public Direction? Direction { get; set; }

        public Need(NeedTypes type)
        {
            Type = type;
        }
    }
}
