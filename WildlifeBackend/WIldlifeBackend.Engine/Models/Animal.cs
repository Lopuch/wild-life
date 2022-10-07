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
        public double Rotation { get; set; }
        /// <summary>
        /// m/s
        /// </summary>
        public double Speed { get; set; } = 0.1;
        public List<Need> Needs { get; set; }

        public double NeckLenght { get; set; } = 0.3;
        public double BiteSize { get; set; } = 0.1;
        // ms per bite
        public double BiteInterval { get; set; } = 1000;
        public DateTime LastBiteTime { get; set; } = DateTime.Now;

        public double SightDistance { get; set; } = 20;


        public Animal(int id, Position position)
        {
            Id = id;
            Position = position;

            Needs = new List<Need>
            {
                new Need(Need.NeedTypes.Eat),
                //new Need(Need.NeedTypes.Rest),
            };
        }

        public bool IsTimeForBite()
        {
            return LastBiteTime.AddMilliseconds(BiteInterval) <= DateTime.Now;
        }
    }
}
