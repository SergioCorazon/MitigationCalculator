namespace MitigationCalculator.Models
{
    public class SimplifiedJob
    {
        public string JobName { get; set; }
        public IList<string> Mitsnames { get; set;}
        public SimplifiedJob(string nameJob, IList<string> listMits) {
            JobName = nameJob;
            Mitsnames = listMits;
        }
    }
}