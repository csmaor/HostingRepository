using System;
using Lynes.ReportsServer.Core.DataModels;

namespace Lynes.ReportsServer.Core.DataView
{
    public class LocationsDataView : IdentifierData
    {
        public virtual DateTime Time { get; set; }

       public virtual double Latitude { get; set; }

       public virtual double Longitude { get; set; }

       public virtual double Accuracy { get; set; }

        public virtual float X { get; set; }

        public virtual float Y { get; set; }

        public virtual float Z { get; set; }
    }
}
