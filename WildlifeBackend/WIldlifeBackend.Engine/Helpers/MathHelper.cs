using WildlifeBackend.Engine.Extensions;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Helpers
{
    public class MathHelper
    {
        private static Random _random = new Random();

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

        public static double CalculateAngle(Position start, Position arrival)
        {
            var deltaX = Math.Pow((arrival.X - start.X), 2);
            var deltaY = Math.Pow((arrival.Y - start.Y), 2);

            var radian = Math.Atan2((arrival.Y - start.Y), (arrival.X - start.X));
            var angle = (radian * (180 / Math.PI) + 360) % 360;

            return angle;
        }

        public static double CalculateDistance(Position start, Position arrival)
        {
            var deltaX = Math.Pow((arrival.X - start.X), 2);
            var deltaY = Math.Pow((arrival.Y - start.Y), 2);

            var distance = Math.Sqrt(deltaY + deltaX);

            return distance;
        }

        public static double GetRandomDouble(double min, double max)
        {
            var half_min = min / 2.0;
            var half_max = max / 2.0;
            var average = half_min + half_max;
            var factor = max - average;

            return (2.0 * _random.NextDouble() - 1.0) * factor + average;
        }


    }
}
