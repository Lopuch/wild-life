using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeBackend.Engine.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        /// <summary>
        /// m/s
        /// </summary>
        public double Speed { get; set; }
        public List<Need> Needs { get; set; }


        public Animal(int id, Position position)
        {
            Id = id;
            Position = position;

            Needs = new List<Need>
            {
                new Need(Need.NeedTypes.Eat),
                new Need(Need.NeedTypes.Rest),
            };
        }
    }
}
