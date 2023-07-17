using MitigationCalculator.Models;
using Newtonsoft.Json;

namespace MitigationCalculator.Services
{
    public class MitigationService
    {
        private IList<Mitigation> mitigationList = new List<Mitigation>();
        public MitigationService() {
            mitigationList = GetDataFromJson();
        }

        //Get the mittigation given a name.

        public Mitigation GetMitigationByName(string name)
        {
            return mitigationList.Where(i => i.Name == name).FirstOrDefault();
        }

        //Get the mitigations of a job.
        public IList<Mitigation> GetMitigationBySimplifiedJob(SimplifiedJob job)
        {
            return mitigationList.Where(i => job.Mitsnames.Contains(i.Name)).ToList();
        }

        public IList<Mitigation> GetAllMitigations()
        {
            return this.mitigationList;
        }


        private IList<Mitigation> GetDataFromJson() {
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
