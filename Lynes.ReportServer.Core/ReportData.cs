using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    public class ReportData
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual double Velocity { get; set; }

        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double Altitude { get; set; }

    }
}
