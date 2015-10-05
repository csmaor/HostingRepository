using Lynes.ReportsServer.Core;
using Lynes.ReportsServer.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Lynes.ReportsServer.Core.DataModels;
using System.Web.Services;
using System.IO;

namespace Lynes.ReportsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    [WebService(Namespace = "http://Lynes.com/")]
    public class ReportsService : IReportsService
    {
        private DBService m_dbService;
        private const string DATE_TIME_FORMAT = "ddMMyyyyHHmmss";

        public ReportsService()
        {
            m_dbService = new DBService();
            m_dbService.Init();
        }

        public void ReportLocation(string identifier, string dateTimeStringFormat, string latitudeString, string longitudeString, string accuracyString)
        {
            DateTime dateTime;
            double latitude;
            double longitude;
            double accuracy;
            bool isValidParse;

            isValidParse = (DateTime.TryParseExact(dateTimeStringFormat,
                           DATE_TIME_FORMAT,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out dateTime));
            if (!isValidParse)
                return;

            isValidParse = Double.TryParse(latitudeString, out latitude);
            if (!isValidParse)
                return;

            isValidParse = Double.TryParse(longitudeString, out longitude);
            if (!isValidParse)
                return;

            isValidParse = Double.TryParse(accuracyString, out accuracy);
            if (!isValidParse)
                return;

            LocationData data = new LocationData() { Identifier = identifier,  Time = dateTime,
                                                    Latitude = latitude,  Longitude = longitude, Accuracy = accuracy };
            m_dbService.SaveLocation(data);
        }
        
        public void ReportOperation(string identifier, string dateTimeStringFormat, string operation)
        {
            DateTime dateTime;
            bool isValidParse;

            isValidParse = (DateTime.TryParseExact(dateTimeStringFormat,
                           DATE_TIME_FORMAT,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out dateTime));
            if (!isValidParse)
                return;

            OperationData data = new OperationData() { Identifier = identifier, Time = dateTime, Operation = operation };
            m_dbService.SaveOperation(data);
        }

        public void ReportPlace(string identifier, string dateTimeStringFormat, string placeId, string placeName)
        {
            DateTime dateTime;
            bool isValidParse;

            isValidParse = (DateTime.TryParseExact(dateTimeStringFormat,
                           DATE_TIME_FORMAT,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out dateTime));
            if (!isValidParse)
                return;

            PlaceData data = new PlaceData() { Identifier = identifier, Time = dateTime, PlaceId = placeId, PlaceName = placeName };
            m_dbService.SavePlace(data);
        }

        public void ReportAcceleration(string identifier, string dateTimeStringFormat, string sx, string sy, string sz)
        {
            DateTime dateTime;
            float x;
            float y;
            float z;
            bool isValidParse;

            isValidParse = (DateTime.TryParseExact(dateTimeStringFormat,
                           DATE_TIME_FORMAT,
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out dateTime));
            if (!isValidParse)
                return;

            isValidParse = float.TryParse(sx, out x);
            if (!isValidParse)
                return;

            isValidParse = float.TryParse(sy, out y);
            if (!isValidParse)
                return;

            isValidParse = float.TryParse(sz, out z);
            if (!isValidParse)
                return;
            AccelerometerData data = new AccelerometerData() { Identifier = identifier, Time = dateTime, X = x, Y = y, Z = z };
            m_dbService.SaveAcceleration(data);
        }
        
        public void CteateCsv(string identifier)
        {
            DateTime now = DateTime.Now;
            string nowStringFormat = now.ToString(DATE_TIME_FORMAT);
            //string identifier = "MyId";

            ReportLocation(identifier, nowStringFormat, "31.0", "10.0", "1");
            ReportLocation(identifier, nowStringFormat, "32.0", "20.0", "2");
            ReportLocation(identifier, nowStringFormat, "33.0", "30.0", "3");
            ReportLocation(identifier, nowStringFormat, "34.0", "40.0", "4");
            ReportLocation(identifier, nowStringFormat, "35.0", "50.0", "5");
            ReportAcceleration(identifier, nowStringFormat, "10", "20", "30");
            ReportAcceleration(identifier, nowStringFormat, "40", "50", "60");

            m_dbService.ExportCSVs("C://");
        }

        public void Close()
        {
            m_dbService.Close();
        }
    }
}
