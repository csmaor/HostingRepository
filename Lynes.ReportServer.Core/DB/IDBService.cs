using System.Collections.Generic;
using Lynes.ReportsServer.Core.DataModels;

namespace Lynes.ReportsServer.Core.DB
{
    public interface IDBService
    {
        void Init();
        void Close();

        void SaveLocation(LocationData data);
        void SaveOperation(OperationData data);
        void SavePlace(PlaceData data);
        void SaveAcceleration(AccelerometerData data);

        IList<LocationData> GetLocationsData();
        IList<OperationData> GetOperationsData();
        IList<PlaceData> GetPlacesData();
        IList<AccelerometerData> GetAccelerationData();

        void ExportCSVs(string path);
    }
}
