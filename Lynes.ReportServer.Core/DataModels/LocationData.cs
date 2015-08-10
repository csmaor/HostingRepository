using System;

namespace Lynes.ReportsServer.Core.DataModels
{
    public class LocationData : IdentifierData
    {
        public virtual DateTime Time { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }
    }
}
