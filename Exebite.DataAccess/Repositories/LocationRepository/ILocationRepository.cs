﻿using Exebite.Model;

namespace Exebite.DataAccess.Repositories
{
    public interface ILocationRepository : IDatabaseRepository<Location,LocationQueryModel>
    {
        // Add functions specific for ILocationHandler
    }
}