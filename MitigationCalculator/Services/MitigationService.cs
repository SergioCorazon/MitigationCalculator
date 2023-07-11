using MitigationCalculator.Models;
using Newtonsoft.Json;

namespace MitigationCalculator.Services
{
    public class MitigationService
    {
        public IList<Mitigation> GetDataFromJson() {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Assets\Mitigations.json");
            string filePath = Path.GetFullPath(sFile);
            using StreamReader reader = new(filePath);
            var json = reader.ReadToEnd();
            List<Mitigation>? mitigationshollyfuck = JsonConvert.DeserializeObject<List<Mitigation>>(json);
            if (mitigationshollyfuck is not null) return mitigationshollyfuck;
            return new List<Mitigation>();
        }
    }
}
