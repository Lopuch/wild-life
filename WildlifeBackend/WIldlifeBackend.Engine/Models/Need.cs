using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeBackend.Engine.Models
{
    public class Need
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
        public Position? Position { get; set; }

        public Need(NeedTypes type)
        {
            Type = type;
        }
    }
}
