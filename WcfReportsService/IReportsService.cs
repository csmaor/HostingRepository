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
        [WebGet(UriTemplate = "ReportLocation/{identifier}/{dateTime}/{latitude}/{longitude}/{accuracy}")]
        [OperationContract]
        void ReportLocation(string identifier, string dateTime, string latitude, string longitude, string accuracy);

        [WebGet(UriTemplate = "ReportOperation/{identifier}/{dateTime}/{operation}")]
        [OperationContract]
        void ReportOperation(string identifier, string dateTime, string operation);

        [WebGet(UriTemplate = "ReportPlace/{identifier}/{dateTime}/{placeId}/{placeName}")]
        [OperationContract]
        void ReportPlace(string identifier, string dateTime, string placeId, string placeName);

        [WebGet(UriTemplate = "ReportAcceleration/{identifier}/{dateTime}/{x}/{y}/{z}")]
        [OperationContract]
        void ReportAcceleration(string identifier, string dateTime, string x, string y, string z);

        [WebGet(UriTemplate = "CteateCsv/{password}")]
        [OperationContract]
        void CteateCsv(string password);
    }
}
