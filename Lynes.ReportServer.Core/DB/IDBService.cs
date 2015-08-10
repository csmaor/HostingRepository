using Lynes.ReportsServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynes.ReportsServer.Core.DataModels;

namespace Lynes.ReportsServer.Core.DB
{
    public interface IDBService
    {
        void Init();
        void Close();

        void SaveReport(LocationData data);
        IList<LocationData> GetAllData();
    }
}
