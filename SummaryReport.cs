using Items_Report.Models;
using Newtonsoft.Json;
using System.IO;

namespace Items_Report
{
    internal sealed class ItemsSummaryReportFactory
    {
        public Root LoadDataFromJson()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleData.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<Root>(jsonContent);
        }
    }
}