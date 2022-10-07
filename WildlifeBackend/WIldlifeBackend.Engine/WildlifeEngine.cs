using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Dtos;
using WildlifeBackend.Engine.Models;
using WildlifeBackend.Engine.Services;

namespace WildlifeBackend.Engine
{
    public class WildlifeEngine
    {
        private List<Animal> animals;
        internal List<Food> foods;

        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));
        private readonly CancellationToken _timerCancel = new CancellationToken();

        private DateTime lastTick { get; set; } = DateTime.Now;

        private readonly EnvironmentService _environmentService;
        private readonly MotionService _motionService;
        private readonly NeedsService _needsService;

        public WildlifeEngine()
        {
            _environmentService = new EnvironmentService(this);
            _motionService = new MotionService(this, _environmentService);
            _needsService = new NeedsService(_environmentService);

            foods = new List<Food>();

            animals = new List<Animal>
            {
                new Animal(1, new Position(0, 0)),
                new Animal(2, new Position(1, 1)),
                new Animal(3, new Position(2, 2)),
                new Animal(4, new Position(3, 3)),

            };

            

            _ = ComputeAsync(_timerCancel);
        }

        private async Task ComputeAsync(CancellationToken cancellationToken)
        {
            while(await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
            {
                _environmentService.Calculate();

                for (var i = 0; i < animals.Count; i++)
                {
                    var animal = animals[i];
                    _needsService.Calculate(animal);
                    _motionService.Calculate(animal);
                }

                lastTick = DateTime.Now;
            }
        }

        internal double GetFrameMs()
        {
            return (DateTime.Now - lastTick).TotalMilliseconds;
        }

        public WorldDto GetWorld()
        {
            var worldDto = new WorldDto(animals, foods);

            return worldDto;
        }
    }
}
