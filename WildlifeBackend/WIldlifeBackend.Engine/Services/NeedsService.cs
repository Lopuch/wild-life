using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Services
{
    internal class NeedsService
    {
        private readonly EnvironmentService _environmentService;

        public NeedsService(EnvironmentService environmentService)
        {
            _environmentService = environmentService;
        }

        public void Calculate(Animal animal)
        {
            for(int i=0; i < animal.Needs.Count; i++)
            {
                var need = animal.Needs[i];

                if(need.Type == Need.NeedTypes.Eat)
                {
                    var food = _environmentService.GetNearestFoodInDistance(animal.Position, animal.SightDistance);
                    if(food is null)
                    {
                        need.Position = null;
                        continue;
                    }

                    need.Position = food.Position;
                }
            }
        }

        
    }
}
