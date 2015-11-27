using System;
using System.Collections.Generic;
using System.Reflection;
using Lynes.ReportsServer.Core.DataModels;
using Lynes.ReportsServer.Core.DB;
using NUnit.Framework;

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
        }

        [Test]
        public void TestSavingData()
        {
            DateTime now = DateTime.Now;
            string nowStringFormat = now.ToString("ddMMyyyyHHmmss");
            string id = "MyId";

            m_reportsService.ReportLocation(id, nowStringFormat, "30.0", "30.0", "0");
            m_reportsService.ReportLocation(id, nowStringFormat, "30.0", "30.0", "0");
            m_reportsService.ReportLocation(id, nowStringFormat, "30.0", "30.0", "0");
            m_reportsService.ReportLocation(id, nowStringFormat, "30.0", "30.0", "0");
            m_reportsService.ReportLocation(id, nowStringFormat, "30.0", "30.0", "0");

            IList<LocationData> allData = m_dbService.GetLocationsData();
            LocationData lastLoadedData = allData[0];
            Assert.AreEqual(now.Date, lastLoadedData.Time.Date, "Can't load saved data");

            m_reportsService.ReportOperation(id, nowStringFormat, "Supermarket");
            IList<OperationData> operations = m_dbService.GetOperationsData();
            OperationData lastOperation = operations[0];
            Assert.AreEqual("Supermarket", lastOperation.Operation, "Operation didn't saved properly");

            m_reportsService.ReportPlace(id, nowStringFormat, "Supermarket1", "Suprtmarker");
            IList<PlaceData> places = m_dbService.GetPlacesData();
            PlaceData lastPlace = places[0];
            Assert.AreEqual("Supermarket1", lastPlace.PlaceId, "Place didn't saved properly");

            m_reportsService.ReportAccelerometer(id, nowStringFormat, "20", "20", "20", "1");
            IList<AccelerometerData> acc = m_dbService.GetAccelerationData();
            AccelerometerData accData = acc[0];
            Assert.AreEqual(20, accData.X, "Acceleration X didn't saved properly");

            m_reportsService.CteateCsv(id);
        }

        [TearDown]
        public void AfterEachTest()
        {
            m_reportsService.Close();
        }
    }
}
