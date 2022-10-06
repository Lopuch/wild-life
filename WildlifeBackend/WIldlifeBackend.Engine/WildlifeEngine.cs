using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine
{
    public class WildlifeEngine
    {

        private List<Animal> animals = new List<Animal>();

        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));
        private readonly CancellationToken _timerCancel;

        internal DateTime lastTick { get; private set; } = DateTime.Now;

        public WildlifeEngine()
        {
            animals = new List<Animal>();

            _timerCancel = new CancellationToken();
            _ = ComputeAsync(_timerCancel);
            
        }

        private async Task ComputeAsync(CancellationToken cancellationToken)
        {
            while(await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
            {

            }
        }
    }
}
