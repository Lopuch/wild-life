using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Helpers;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Services
{
    internal class MotionService
    {
        private readonly WildlifeEngine _engine;
        private readonly EnvironmentService _environmentService;

        public MotionService(WildlifeEngine engine, EnvironmentService environmentService)
        {
            _engine = engine;
            _environmentService = environmentService;
        }

        public void Calculate(Animal animal)
        {
            var need = animal.Needs[0];

            RotateAndMove(animal, need);
            DoAction(animal, need);
        }

        internal void RotateAndMove(Animal animal, Need need)
        {
            if (need.Position is null)
            {
                animal.Speed = 0;
                return;
            }

            animal.Rotation = MathHelper.CalculateAngle(animal.Position, (Position)need.Position);

            var nextPos = MathHelper.CalculateNextPosition(animal.Position, animal.Rotation, animal.Speed, _engine.GetFrameMs());

            if(MathHelper.CalculateDistance(animal.Position, nextPos) > 20)
            {

            }

            animal.Position = nextPos;
        }

        internal void DoAction(Animal animal, Need need)
        {
            if(need.Type == Need.NeedTypes.Eat)
            {
                if(!animal.IsTimeForBite())
                {
                    return;
                }

                var food = _environmentService.GetNearestFoodInDistance(animal.Position, animal.NeckLenght);
                if(food is null)
                {
                    return;
                }

                var biteSize = Math.Min(animal.BiteSize, food.Mass);

                food.Mass -= biteSize;

            }
        }


    }
}
