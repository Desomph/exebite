﻿using System.Collections.Generic;
using Exebite.DomainModel;

namespace Exebite.DataAccess.Repositories
{
    public class DailyMenuInsertModel
    {
        public int RestaurantId { get; set; }

        public List<Food> Foods { get; set; } = new List<Food>();
    }
}