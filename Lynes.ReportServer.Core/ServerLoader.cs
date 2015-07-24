using log4net;
using Lynes.ReportsServer.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    public class ServerLoader
    {
        private static ILog s_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ServerFacadeImpl m_facade;

        public void InitServer()
        {
            s_log.Info("Initializing Reports Server");
            m_facade = new ServerFacadeImpl();

            InitDB();
        }

        private void InitDB()
        {
            DBService db = new DBService();
            db.Init();
            m_facade.SetDBService(db);
        }

        public void Close()
        {
            s_log.Info("Closing The Server");
            m_facade.Close();
        }
    }
}
