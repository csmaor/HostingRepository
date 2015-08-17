using System;

namespace Lynes.ReportsServer.Core.DataModels
{
    public class PlaceData : IdentifierData
    {
        public virtual DateTime Time { get; set; }
        public virtual string PlaceId { get; set; }
        public virtual string PlaceName { get; set; }
    }
}
