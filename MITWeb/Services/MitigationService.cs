using System.Runtime.Intrinsics.X86;
using MITWeb.Models;
using Newtonsoft.Json;

namespace MITWeb.Services
{
    public class MitigationService : IMitigationService
    {
        public IList<Mitigation> mitigationList = new List<Mitigation>();
        public MitigationService() {
            mitigationList = GetDataFromJson();
        }

        public string ReadMitigationFromJsonAndInsertIntoSQL()
        {
            IList<Mitigation> auxList = new List<Mitigation>();
            auxList = GetDataFromJson();
            string sql = "INSERT INTO MITIGATION(MITNAME, BOSSMAGICDDPERC, BOSSPHYSICALDDPERC, BOSSFLATDDPERC, PARTYMAGICDEFPERC," +
                    "PARTYPHYSICALDEFPERC, SHIELD) VALUES";
            //string sql2 = "('{0}',{1},{2},{3},{4},{5},{6}),";

            foreach (var aux in auxList)
            {
                sql += "('" + aux.Name + "', " + aux.BossMagicDDownPerc + ", " + aux.BossPhysicalDDownPerc + ", " + aux.BossFlatDDownPerc +
                    ", " + aux.PartyMagicDefPerc + ", " + aux.PartyPhysicalDefPerc + ", " + aux.Shield + "),";
                //sql2 = string.Format(sql2, aux.Name, aux.BossMagicDDownPerc, aux.BossPhysicalDDownPerc, aux.BossFlatDDownPerc, aux.PartyMagicDefPerc, aux.PartyPhysicalDefPerc, aux.Shield);
            }

            sql = sql.Substring(0, sql.Length - 1) + ";";
            return sql;

            //int x = 0;
            //int y = auxList.Count;
            //auxList.Distinct().ToList().ForEach(aux => {
            //    x++;
            //    //auxList.Select(aux =>
            //    sql2= string.Format(sql2, aux.Name, aux.BossMagicDDownPerc, aux.BossPhysicalDDownPerc, aux.BossFlatDDownPerc, aux.PartyMagicDefPerc, aux.PartyPhysicalDefPerc, aux.Shield);
            //});
            //return sql + (sql2.Substring(0, sql2.Length - 1) + ";");

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
