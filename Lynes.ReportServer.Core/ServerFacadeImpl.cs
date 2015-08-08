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
