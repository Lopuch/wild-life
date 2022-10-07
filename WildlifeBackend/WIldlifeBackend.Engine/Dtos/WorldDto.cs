using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeBackend.Engine.Models;

namespace WildlifeBackend.Engine.Dtos
{
    public class WorldDto
    {
        public List<Animal> Animals { get; set; }

        public List<Food> Foods { get; set; }

        public WorldDto(List<Animal> animals, List<Food> foods)
        {
            Animals = animals;
            Foods = foods;
        }
    }
}
