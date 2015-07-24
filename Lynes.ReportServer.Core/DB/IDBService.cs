using Lynes.ReportsServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core.DB
{
    public interface IDBService
    {
        void Init();
        void Close();

        void SaveReport(ReportData data);
        IList<ReportData> GetAllData();
    }
}
