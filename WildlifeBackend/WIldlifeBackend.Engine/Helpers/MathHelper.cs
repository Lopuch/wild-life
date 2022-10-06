using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Extensions;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Helpers
{
    public class MathHelper
    {
        public static Position CalculateNextPosition(Position actualPos, double rotation, double speedPerSec, double timeMs)
        {
            if(timeMs == 0)
            {
                return actualPos;
            }

            if(timeMs < 0)
            {
                throw new ArgumentException("Time cannot be zero");
            }

            var timeSec = 1000 / timeMs;
            var distanceTraveled = speedPerSec * timeSec;

            var yAdd = distanceTraveled * Math.Sin(rotation.ToRadians());
            var xAdd = distanceTraveled * Math.Cos(rotation.ToRadians());


            return new Position(actualPos.X + xAdd, actualPos.Y + yAdd);
        }


    }
}
