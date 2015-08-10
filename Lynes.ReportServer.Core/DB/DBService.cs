using log4net;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lynes.ReportsServer.Core.DataModels;

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

        public void SaveReport(LocationData data)
        {
            s_log.Info($"Saving Report Data: {data}");
            m_session.Save(data);
            m_session.Flush();
        }

        public IList<LocationData> GetAllData()
        {
            IQuery q = m_session.CreateQuery("FROM LocationData");
            IList<LocationData> list = q.List<LocationData>();
            return list;
        }

        public void Close()
        {
            s_log.Info("Closing Session");
            m_session.Close();
        }
    }
}
