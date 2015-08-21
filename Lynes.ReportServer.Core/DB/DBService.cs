﻿using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Lynes.ReportsServer.Core.DataModels;
using NHibernate;
using NHibernate.Cfg;
using System.IO;

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

        public void ExportCSVs(string path)
        {
            SortedList<DateTime, IdentifierData> sortedList = new SortedList<DateTime, IdentifierData>();

            IList<LocationData> locations = GetLocationsData();
            foreach (LocationData ld in locations)
                sortedList.Add(ld.Time, ld);

            IList<AccelerometerData> acceleromaters = GetAccelerationData();
            foreach (AccelerometerData ac in acceleromaters)
                sortedList.Add(ac.Time, ac);

            IList<PlaceData> places = GetPlacesData();
            foreach (PlaceData pd in places)
                sortedList.Add(pd.Time, pd);

            IList<OperationData> operations = GetOperationsData();
            foreach (OperationData od in operations)
                sortedList.Add(od.Time, od);



            FileStream fs = new FileStream("Export.csv", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            foreach (KeyValuePair<DateTime, IdentifierData> pair in sortedList)
            {

            }


            
            
        }

        public void Close()
        {
            s_log.Info("Closing Session");
            m_session.Close();
        }
    }
}
