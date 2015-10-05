using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lynes.ReportsServer.Core.DataModels;
using Lynes.ReportsServer.Core.DB;
using Lynes.ReportsService;

namespace CreatorCsv
{
    public partial class CreatorCSV : Form
    {
        private ReportsService m_reportsService;
        private IDBService m_dbService;

        public CreatorCSV()
        {
            InitializeComponent();
            /*  m_dbService = new DBService();
              m_dbService.Init();*/

            Thread t = new Thread(WriteY);       
            t.Start();                             
        }
        private void WriteY()
        {
            m_reportsService = new ReportsService();
            Type reportsServiceType = m_reportsService.GetType();
            FieldInfo fi = reportsServiceType.GetField("m_dbService", BindingFlags.NonPublic | BindingFlags.Instance);
            m_dbService = (IDBService)fi.GetValue(m_reportsService);
        }
            

        private void btnCreateCsv_Click(object sender, EventArgs e)
        {
           // allData.Count()
            string filePath = "C://" + "filename.csv";

            IList<LocationData> allData = m_dbService.GetLocationsData();

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string[][] output = new string[][] {
            new string[]{"Id", "Time", "Latitude", "Longitude"} /*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
            };
            int length = output.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < 2; index++)
            {
                LocationData lastLoadedData = allData[index];
                lastLoadedData.Time.ToString("yyyyMMddHHmmss");
                sb.AppendLine(string.Join("a", output[index]));
            }
            File.AppendAllText(filePath, sb.ToString());
        }

        private void btnAutoCSV_Click(object sender, EventArgs e)
        {

        }
    }
}
