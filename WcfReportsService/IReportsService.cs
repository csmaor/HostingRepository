using Lynes.ReportsServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lynes.ReportsService
{
    [ServiceContract]
    public interface IReportsService
    {
        [WebInvoke(Method = "POST", UriTemplate = "ReportData")]
        [OperationContract]
        void Report(ReportData data);
    }

    
}
