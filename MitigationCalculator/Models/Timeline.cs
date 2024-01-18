namespace MitigationCalculator.Models
{
    public class Timeline
    {

        //Name of the fight
        //Time
        //Attacks
        //Mitigation of the attacks
        //Boolean that tells you if you survived
        public string BossName { get; set; }
        public int EnrageTime { get; set; }
        public IList<Attack> ListOfAttacks { get; set; }

        public IList<AppliedMitigation> ListOfAppliedMitigations { get; set; }

        public IList<MitigatedAttacks> ListOfMitigatedAttacks { get; set; }

        public Tier Tier { get; set; }

        

    }
}
