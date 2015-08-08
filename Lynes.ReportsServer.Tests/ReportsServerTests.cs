using Lynes.ReportsServer.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ReportData data = new ReportData() { Time = now, Latitude = 30.0, Longitude = 30.0 };
            ServerFacade.Instance.DBService.SaveReport(data);

            IList<ReportData> allData = ServerFacade.Instance.DBService.GetAllData();
            ReportData lastLoadedData = allData[0];
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
