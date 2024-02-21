using MITWeb.Models;

namespace MITWeb.Services
{
    public interface IJobService
    {
        string ReadJobFromJsonAndInstertIntoSQL();
        string Insertjobmitigation();
        SimplifiedJob GetASimplifiedJobByName(string name);
        IList<Job> GetJobs();
        IList<SimplifiedJob> GetDataFromJson();
    }
}
