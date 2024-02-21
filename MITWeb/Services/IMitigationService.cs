using MITWeb.Models;

namespace MITWeb.Services
{
    public interface IMitigationService
    {
        string ReadMitigationFromJsonAndInsertIntoSQL();
        Mitigation GetMitigationByName(string name);
        IList<Mitigation> GetMitigationBySimplifiedJob(SimplifiedJob job);
        IList<Mitigation> GetAllMitigations();
    }
}
