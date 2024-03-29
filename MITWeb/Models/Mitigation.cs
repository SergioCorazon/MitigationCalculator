﻿using System.Reflection.PortableExecutable;

namespace MITWeb.Models
{
    //TODO: Add comments!
    public class Mitigation
    {
        public int mitID { get; set; }
        public Mitigation(string _Name) { this.Name = _Name; }
        public string Name { get; set; }
        
        public int Duration { get; set; }

        public int Cooldown { get; set; }

        public int BossMagicDDownPerc{ get; set; }

        public int BossPhysicalDDownPerc{ get; set; }
        
        public int BossFlatDDownPerc{ get; set; }

        public int PartyMagicDefPerc{ get; set; }

        public int PartyPhysicalDefPerc { get; set; }

        public int PartyFlatDefPerc { get; set; }

        public int Shield { get; set; }

    }
}
