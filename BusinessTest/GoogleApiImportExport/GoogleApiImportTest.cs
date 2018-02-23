﻿using BusinessTest;
using Exebite.Business;
using Exebite.DataAccess;
using Exebite.GoogleSpreadsheetApi.GoogleSSFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.Resolution;

namespace Business.Test.GoogleApiImportExport
{
    [TestClass]
    public class GoogleApiImportTest
    {
        IGoogleSheetServiceFactory _googleSheetServiceFactory;
        IGoogleSpreadsheetIdFactory _googleSpreadsheetIdFactory;
        IGoogleDataImporter _googleDataImporter;
        IUnityContainer _container;
        IRestarauntService _restarauntService;
        IRestaurantRepository _restaurantRepository;
        [TestInitialize]
        public void Setup()
        {
            _container = new UnityContainer();
            UnityConfig.RegisterTypes(_container);
            
            _googleSheetServiceFactory = _container.Resolve<IGoogleSheetServiceFactory>();
            _googleSpreadsheetIdFactory = _container.Resolve<IGoogleSpreadsheetIdFactory>();
            _restaurantRepository = _container.Resolve<IRestaurantRepository>();

            _restarauntService = _container.Resolve<IRestarauntService>(new ParameterOverrides
            {
                { "restaurantHandler", _restaurantRepository}

            }.OnType<RestarauntService>());
            _googleDataImporter = _container.Resolve<IGoogleDataImporter>(new ParameterOverrides
            {
                { "GoogleSSFactory", _googleSheetServiceFactory },
                { "GoogleSSIdFactory", _googleSpreadsheetIdFactory },
                { "restarauntService", _restarauntService }
            }.OnType<GoogleApiImport>());
        }

        [TestMethod]
        public void GetHistoricalData()
        {
            var restult = _googleDataImporter.GetHistoricalData();
            Assert.AreNotEqual(restult.Count, 0);
        }
    }
}
