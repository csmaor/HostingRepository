using Lynes.ReportsServer.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    public abstract class ServerFacade
    {
        public static ServerFacade Instance { get; protected set; }

        public IDBService DBService { get; protected set; }
    }
}
