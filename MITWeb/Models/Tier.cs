namespace MITWeb.Models
{
    public class Tier
    {
        private string? Name { get; set; }
        private int MinDmg;
        public int GetMinDmg() { return this.MinDmg; }
        public void SetMinDmg(int value) { this.MinDmg = value; }

    }
}
