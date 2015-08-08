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
        private DBService m_dbService;
        private HttpServer m_httpServer;

        public void InitServer()
        {
            s_log.Info("Initializing Reports Server");
            m_facade = new ServerFacadeImpl();

            InitDB();
            InitHttpServer();
        }

        private void InitDB()
        {
            m_dbService = new DBService();
            m_dbService.Init();
            m_facade.SetDBService(m_dbService);
        }

        private void InitHttpServer()
        {
            m_httpServer = new HttpServer();
            m_httpServer.Start();
        }

        public void Close()
        {
            s_log.Info("Closing The Server");
            
            m_httpServer.Start();
            m_dbService.Close();
            m_facade.Close();
        }
    }
}
