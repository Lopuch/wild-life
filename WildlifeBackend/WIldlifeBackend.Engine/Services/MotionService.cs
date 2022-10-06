using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIldlifeBackend.Engine.Models;

namespace WIldlifeBackend.Engine.Services
{
    internal class MotionService
    {
        public void Calculate(Animal animal)
        {
            var need = animal.Needs[0];

            if(need.Direction is null)
            {

                animal.Speed = 0;
                return;
            }
        }
    }
}
