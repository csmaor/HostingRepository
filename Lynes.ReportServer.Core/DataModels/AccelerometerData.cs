using System;

namespace Lynes.ReportsServer.Core.DataModels
{
    public class AccelerometerData : IdentifierData
    {
        public virtual DateTime Time { get; set; }

        public virtual float X { get; set; }

        public virtual float Y { get; set; }

        public virtual float Z { get; set; }

        public virtual double Accuracy { get; set; }
    }
}
