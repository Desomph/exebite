﻿using System.Collections.Generic;

namespace Exebite.DomainModel
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Food> Foods { get; set; } = new List<Food>();

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
