using Lynes.ReportsServer.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    [ServiceContract]
    public interface IReportService
    {
        [WebInvoke(Method = "POST", UriTemplate = "ReportData")]
        [OperationContract]
        void Report(ReportData data);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public  class ReportService : IReportService
    {
        private DBService m_dbService;

        public ReportService()
        {
            m_dbService = new DBService();
        }

        public void Report(ReportData data)
        {
            m_dbService.SaveReport(data);
        }
    }
}
