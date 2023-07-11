using MitigationCalculator.Models;
using Newtonsoft.Json;

namespace MitigationCalculator.Services
{
    public class JobService
    {
        public IList<SimplifiedJob> GetDataFromJson() {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Assets\simplifiedjoblist.json");
            string filePath = Path.GetFullPath(sFile);
            using StreamReader reader = new(filePath);
            var json = reader.ReadToEnd();
            List<SimplifiedJob>? mitigationshollyfuck = JsonConvert.DeserializeObject<List<SimplifiedJob>>(json);
            if (mitigationshollyfuck is not null) return mitigationshollyfuck;
            return new List<SimplifiedJob>();
        }
    }
}
