using System.Reflection;
using log4net;
using Lynes.ReportsServer.Core.DB;

namespace Lynes.ReportsServer.Core
{
    public class ServerFacadeImpl : ServerFacade
    {
        private static ILog s_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ServerFacadeImpl()
        {
            Instance = this;
        } 

        public void SetDBService(IDBService dbService)
        {
            DBService = dbService;
        }

        internal void Close()
        { 
        
        }
    }
}
