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
        void ReportLocation(string identifier, DateTime dateTime, double latitude, double longitude, double accuracy);

        [WebInvoke(Method = "POST", UriTemplate = "ReportOperation")]
        [OperationContract]
        void ReportOperation(string identifier, DateTime dateTime, string operation);

        [WebInvoke(Method = "POST", UriTemplate = "ReportPlace")]
        [OperationContract]
        void ReportPlace(string identifier, DateTime dateTime, string placeId, string placeName);

        [WebInvoke(Method = "POST", UriTemplate = "ReportPlace")]
        [OperationContract]
        void ReportAcceleration(string identifier, DateTime dateTime, float x, float y, float z);
    }

    
}
