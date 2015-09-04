using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lynes.ReportsServer.Core.DataModels;
using System.IO;

namespace Lynes.ReportsServer.Core.DB
{
    public class CSVDBService : IDBService
    {
        private Dictionary<string, StringBuilder> m_idToSB;

        public CSVDBService()
        {
            m_idToSB = new Dictionary<string, StringBuilder>();
        }

        public void Init()
        {
            string fileName = GetNextFileName(string.Empty);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
        }

        private string GetNextFileName(string id)
        {
            DateTime now = DateTime.UtcNow;
            string result = string.Format("{0}.{1}.{2}_{3}.{4}.{5}.csv", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second);
            return result;
        }



        public void SaveAcceleration(AccelerometerData data)
        {
            throw new NotImplementedException();
        }

        public void SaveLocation(LocationData data)
        {
            throw new NotImplementedException();
        }

        public void SaveOperation(OperationData data)
        {
            throw new NotImplementedException();
        }

        public void SavePlace(PlaceData data)
        {
            throw new NotImplementedException();
        }

        public void ExportCSVs(string path)
        {
            throw new NotImplementedException();
        }

        public IList<AccelerometerData> GetAccelerationData()
        {
            throw new NotImplementedException();
        }

        public IList<LocationData> GetLocationsData()
        {
            throw new NotImplementedException();
        }

        public IList<OperationData> GetOperationsData()
        {
            throw new NotImplementedException();
        }

        public IList<PlaceData> GetPlacesData()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
