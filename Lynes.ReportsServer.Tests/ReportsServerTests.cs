﻿using Lynes.ReportsServer.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynes.ReportsServer.Core.DataModels;
using Lynes.ReportsServer.Core.DB;
using System.Reflection;

namespace Lynes.ReportsServer.Tests
{
    [TestFixture]
    public class ReportsServerTests
    {
        //private ServerLoader m_serverLoader;
        private ReportsService.ReportsService m_reportsService;
        private IDBService m_dbService;


        [SetUp]
        public void BeforeEachTest()
        {
            m_reportsService = new ReportsService.ReportsService();
            Type reportsServiceType = m_reportsService.GetType();
            FieldInfo fi = reportsServiceType.GetField("m_dbService", BindingFlags.NonPublic | BindingFlags.Instance);
            m_dbService = (IDBService)fi.GetValue(m_reportsService);

            //m_serverLoader = new ServerLoader();
            //m_serverLoader.InitServer();
        }

        [Test]
        public void TestSavingData()
        {
            DateTime now = DateTime.Now;
            m_reportsService.ReportData("MyId", now, 30.0, 30.0);

            IList<LocationData> allData = m_dbService.GetLocationsData();
            LocationData lastLoadedData = allData[0];
            Assert.AreEqual(now, lastLoadedData.Time, "Can't load saved data");

            m_reportsService.ReportOperation("MyId", "Supermarket");
            IList<OperationData> operations = m_dbService.GetOperationsData();
            OperationData lastOperation = operations[0];
            Assert.AreEqual("Supermarket", lastOperation.Operation, "Operation didn't saved properly");

            m_reportsService.ReportPlace("MyId", "Supermarket1", "Suprtmarker");
            IList<PlaceData> places = m_dbService.GetPlacesData();
            PlaceData lastPlace = places[0];
            Assert.AreEqual("Supermarket1", lastPlace.PlaceId, "Place didn't saved properly");
        }

        [TearDown]
        public void AfterEachTest()
        {
            m_reportsService.Close();
            //m_serverLoader.Close();
            //m_serverLoader = null;
        }
    }
}
