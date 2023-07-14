namespace MitigationCalculator.Models
{
    public class Job
    {
        public IEnumerable<Mitigation>? Mitigations { get; set; }
        public string? Name { get; set; }
        public Job(string jobName, IEnumerable<Mitigation> jobMitigation) 
        {
            Name = jobName;
            Mitigations = jobMitigation;

        }
        public Job() { }
    }
}
