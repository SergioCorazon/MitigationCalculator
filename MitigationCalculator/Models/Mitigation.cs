using System.Reflection.PortableExecutable;

namespace MitigationCalculator.Models
{
    //TODO: Add comments!
    public class Mitigation
    {
        public Mitigation(string _Name) { this.Name = _Name; }
        public string Name { get; set; }
        public int BossMagicDDownPerc{ get; set; }

        public int BossPhysicalDDownPerc{ get; set; }
        
        public int BossFlatDDownPerc{ get; set; }

        public int PartyMagicDefPerc{ get; set; }

        public int PartyPhysicalDefPerc { get; set; }

        public int PartyFlatDefPerc { get; set; }

        public int Shield { get; set; }

    }
}
