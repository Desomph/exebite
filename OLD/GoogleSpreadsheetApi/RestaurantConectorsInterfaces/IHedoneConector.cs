﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exebite.GoogleSpreadsheetApi.RestaurantConectorsInterfaces
{
    public interface IHedoneConector : IRestaurantConector
    {
        void DnevniMenuSheetSetup();
    }
}