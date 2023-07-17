using MitigationCalculator.Models;
using Newtonsoft.Json;

namespace MitigationCalculator.Services
{
    public class JobService
    {
        private IList<SimplifiedJob> jobSimplifiedList = new List<SimplifiedJob>();

        public JobService() {
            jobSimplifiedList = GetDataFromJson();
        }

        //Get the Job given a jobname.
        public SimplifiedJob GetASimplifiedJobByName(string name)
        {
            return jobSimplifiedList.Where(i => i.JobName == name).FirstOrDefault();
        }

        //LLamar al mitigation Service
        public IList<Job> GetJobs()
        {
            MitigationService mitservice = new MitigationService();
            return this.jobSimplifiedList.Select(i => new Job (i.JobName, mitservice.GetMitigationBySimplifiedJob(i))).ToList();
        }


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
