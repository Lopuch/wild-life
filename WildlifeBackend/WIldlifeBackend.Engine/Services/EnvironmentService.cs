using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Helpers;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Services
{
    internal class EnvironmentService
    {
        private readonly WildlifeEngine _engine;
        private readonly Random _random;

        public EnvironmentService(WildlifeEngine engine)
        {
            _engine = engine;

            _random = new Random();
        }

        public void Calculate()
        {
            _engine.foods = _engine.foods.Where(x => x.Mass > 0).ToList();

            while(_engine.foods.Count < 3)
            {
                var pos = new Position(MathHelper.GetRandomDouble(-5, 5), MathHelper.GetRandomDouble(-5, 5));

                _engine.foods.Add(new Food(pos, 1));
            }
        }

        public Food? GetNearestFoodInDistance(Position pos, double maxDistance)
        {
            Food? nearestFood = null;

            double? nearestDistance = null;

            var foods = _engine.foods.Where(x => x.Mass > 0).ToList();

            for(int i = 1; i < foods.Count; i++)
            {
                var food = foods[i];
                var distance = MathHelper.CalculateDistance(pos, food.Position);
                if(distance > maxDistance)
                {
                    continue;
                }

                if(nearestDistance is null || distance < (double)nearestDistance)
                {
                    nearestDistance = distance;
                    nearestFood = food;
                }
                
            }

            return nearestFood;
        }
    }
}
