namespace MitigationCalculator.Models
{
    public class Job
    {
        public IEnumerable<Mitigation> Mitigations;
        public string Name;
        public Job(string jobName, IEnumerable<Mitigation> jobMitigation) 
        {
            Name = jobName;
            Mitigations = jobMitigation;

        }
    }
}
