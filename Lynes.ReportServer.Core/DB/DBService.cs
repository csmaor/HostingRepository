using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Lynes.ReportsServer.Core.DataModels;
using NHibernate;
using NHibernate.Cfg;
using System.Linq;
using System.IO;
using Lynes.ReportsServer.Core.DataView;
using System.Text;

namespace Lynes.ReportsServer.Core.DB
{
    public class DBService : IDBService
    {
        private static ILog s_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ISession m_session;

        public void Init()
        {
            s_log.Info("Initializing DB Service");
            // Initialize NHibernate
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(LocationData).Assembly);

            // Get ourselves an NHibernate Session
            ISessionFactory sessions = cfg.BuildSessionFactory();
            m_session = sessions.OpenSession();
        }

        public void SaveLocation(LocationData data)
        {
            s_log.Info($"Saving Location Data: {data}");
            m_session.Save(data);
            m_session.Flush();
        }

        public void SaveOperation(OperationData data)
        {
            s_log.Info($"Saving Operation Data: {data}");
            m_session.Save(data);
            m_session.Flush();
        }

        public void SavePlace(PlaceData data)
        {
            s_log.Info($"Saving Place Data: {data}");
            m_session.Save(data);
            m_session.Flush();
        }

        public void SaveAcceleration(AccelerometerData data)
        {
            s_log.Info($"Saving Accelerometer Data: {data}");
            m_session.Save(data);
            m_session.Flush();
        }

        public IList<LocationData> GetLocationsData()
        {
            IQuery q = m_session.CreateQuery("FROM LocationData");
            IList<LocationData> list = q.List<LocationData>();
            return list;
        }


        public IList<OperationData> GetOperationsData()
        {
            IQuery q = m_session.CreateQuery("FROM OperationData");
            IList<OperationData> list = q.List<OperationData>();
            return list;
        }

        public IList<PlaceData> GetPlacesData()
        {
            IQuery q = m_session.CreateQuery("FROM PlaceData");
            IList<PlaceData> list = q.List<PlaceData>();
            return list;
        }

        public IList<AccelerometerData> GetAccelerationData()
        {
            IQuery q = m_session.CreateQuery("FROM AccelerometerData");
            IList<AccelerometerData> list = q.List<AccelerometerData>();
            return list;
        }

        public List<LocationsDataView> GetLocationsDataView()
        {
            IList<LocationData> lstLocationData = GetLocationsData();
            IList<AccelerometerData> lstAccelerationData = GetAccelerationData();

            var query = from ld in lstLocationData
                           join ad in lstAccelerationData on ld.Identifier equals ad.Identifier
                        select new { ld.Identifier, ld.Time, ld.Latitude, ld.Longitude, ld.Accuracy, ad.X, ad.Y, ad.Z } ;

            List<LocationsDataView> listLocationsDataView = new List<LocationsDataView>();
            foreach (var data in query)
            {
                LocationsDataView dataView = new LocationsDataView();
                dataView.Identifier = data.Identifier;
                dataView.Time = data.Time;
                dataView.Latitude = data.Latitude;
                dataView.Longitude = data.Longitude;
                dataView.X = data.X;
                dataView.Y = data.Y;
                dataView.Z = data.Z;
                listLocationsDataView.Add(dataView);
            }

            return listLocationsDataView;
        }

        public void ExportCSVs(string filePath)
        {
            string fileName = string.Format("filename_{0}.csv", DateTime.Now.ToString("HHmmss_ddMMyyyy"));
            string fullPasth = string.Format("{0}{1}", filePath, fileName);

            if (!File.Exists(fullPasth))
                File.Create(fullPasth).Close();

            IList<LocationsDataView> allLocationsData = GetLocationsDataView();

            StringBuilder csv = new StringBuilder();
            string title = string.Format("Id, Time, Latitude, Longitude, accuracy, X, Y, Z{0}", System.Environment.NewLine);
            csv.Append(title);

            foreach (LocationsDataView locationData in allLocationsData)
            {
                string locationDataId = locationData.Identifier.ToString();
                string locationTime = locationData.Time.ToString();
                string locationLatitude = locationData.Latitude.ToString();
                string locationLongitude = locationData.Longitude.ToString();
                string locationAccuracy = locationData.Accuracy.ToString();
                string locationX = locationData.X.ToString();
                string locationY = locationData.Y.ToString();
                string locationZ = locationData.Z.ToString();

                string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}{8}",
                    locationDataId, locationTime, locationLatitude, locationLongitude, locationAccuracy,
                    locationX, locationY, locationZ, System.Environment.NewLine);

                csv.Append(newLine);
            }

            File.AppendAllText(fullPasth, csv.ToString());
        }

        public void Close()
        {
            s_log.Info("Closing Session");
            m_session.Close();
        }
    }
}
