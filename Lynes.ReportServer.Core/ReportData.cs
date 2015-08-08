using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    [DataContract(Namespace = "http://lync.net/ReportService/DataTypes/ReportData")]
    public class ReportData
    {
        public virtual Guid Id { get; set; }

        [DataMember]
        public virtual DateTime Time { get; set; }

        [DataMember]
        public virtual double Latitude { get; set; }

        [DataMember]
        public virtual double Longitude { get; set; }

    }
}
