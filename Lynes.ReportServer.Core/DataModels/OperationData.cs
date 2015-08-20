using System;

namespace Lynes.ReportsServer.Core.DataModels
{
    public class OperationData : IdentifierData
    {
        public virtual DateTime Time { get; set; }
        public virtual string Operation { get; set; }
    }
}
