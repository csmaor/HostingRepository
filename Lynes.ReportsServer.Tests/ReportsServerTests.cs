using Lynes.ReportsServer.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynes.ReportsServer.Core.DataModels;

namespace Lynes.ReportsServer.Tests
{
    [TestFixture]
    public class ReportsServerTests
    {
        private ServerLoader m_serverLoader;

        [SetUp]
        public void BeforeEachTest()
        {
            m_serverLoader = new ServerLoader();
            m_serverLoader.InitServer();
        }

        [Test]
        public void TestSavingData()
        {
            DateTime now = DateTime.Now;
            LocationData data = new LocationData() { Identifier="MyId", Time = now, Latitude = 30.0, Longitude = 30.0 };
            ServerFacade.Instance.DBService.SaveReport(data);

            IList<LocationData> allData = ServerFacade.Instance.DBService.GetAllData();
            LocationData lastLoadedData = allData[0];
            Assert.AreEqual(now, lastLoadedData.Time, "Can't load saved data");
        }

        [TearDown]
        public void AfterEachTest()
        {
            m_serverLoader.Close();
            m_serverLoader = null;
        }
    }
}
