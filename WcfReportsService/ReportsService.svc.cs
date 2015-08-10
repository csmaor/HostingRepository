using Lynes.ReportsServer.Core;
using Lynes.ReportsServer.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lynes.ReportsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ReportsService : IReportsService
    {
        private DBService m_dbService;

        public ReportsService()
        {
            m_dbService = new DBService();
            m_dbService.Init();
        }
        public void ReportData(string identifier, DateTime dateTime, double latitude, double longitude)
        {
            ReportedLocation data = new ReportedLocation() { Identifier = identifier, Latitude = latitude, Longitude = longitude };
        }

        public void ReportOperation(string identifier, string operation)
        {
            throw new NotImplementedException();
        }

        public void ReportPlace(string identifier, string placeId, string placeName)
        {
            throw new NotImplementedException();
        }
    }
}
