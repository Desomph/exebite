﻿using Exebite.Model;

namespace Exebite.DataAccess.Repositories
{
    public interface IMealRepository : IDatabaseRepository<Meal,MealQueryModel>
    {
        // Add functions specific for IMealRepository
    }
}