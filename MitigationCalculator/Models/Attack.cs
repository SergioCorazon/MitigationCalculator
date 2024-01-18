namespace MitigationCalculator.Models
{
    public class Attack
    {
        public Attack(string _Name) { this.Name = _Name; }

        public int Time { get; set; }

        public string Name { get; set; }

        public int BossMagicDamage { get; set; }

        public int BossPhysicalDamage { get; set; }

        public int BossFlatDamage { get; set; }

        public Tier Tier { get; set; }

    }
}
