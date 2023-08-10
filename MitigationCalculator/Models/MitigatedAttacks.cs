namespace MitigationCalculator.Models
{
    public class MitigatedAttacks
    {
        public Attack Attack { get; set; }

        //List of mitigations which is empty until ppl add some mits.
        private IList<Mitigation> ListOfMitigation { get; set; }
        public void SetListOfMitigation (IList<Mitigation> value) { this.ListOfMitigation = value; Calculate(); }    
        public bool DoISurvive { get; set; }
        
        public int HpLeft { get; set; }
        private void Calculate() {

            //Coge el ataque
            //Coge las mitigaciones de ListOfMitigationes
            //Restar al daño del ataque el perc de las mitigaciones segun el tipo de daño
            //Comprobar si llega al minimo de supervivencia

            //Recorro la lista de mitigaciones
            //Resto la mitigacion al ataque porcentualmente
            //Devuelvo el resultado :)

            //el mitigated damage tiene que guardase fuera y es respecto al notmitigateddamage.
            //hacer dos foreach para calcular primero el dd del boss?ç

            int AttackDamage = Attack.BossMagicDamage + Attack.BossPhysicalDamage + Attack.BossFlatDamage;
            int FinalDamage = AttackDamage;

            foreach (var i in ListOfMitigation)
            {
                if (Attack.BossMagicDamage > 0)
                {
                    if (i.BossMagicDDownPerc > 0)
                    {
                        FinalDamage = AttackDamage*(1 - i.BossMagicDDownPerc/100);
                    }
                    else if (i.PartyMagicDefPerc > 0)
                    {
                        FinalDamage = FinalDamage*(1 - i.PartyMagicDefPerc/100);
                    }
                    else if (i.PartyFlatDefPerc > 0)
                    {
                        FinalDamage = FinalDamage*(1- i.PartyFlatDefPerc/100);
                    }
                    //might be loses if we dont calculate shield.
                    else if (i.Shield > 0)
                    {
                        FinalDamage = AttackDamage*(1 -i.Shield/100);
                    }
                }
                else if (Attack.BossPhysicalDamage > 0)
                {
                    if(i.BossPhysicalDDownPerc > 0)
                    {
                        FinalDamage = AttackDamage * (1 - i.BossPhysicalDDownPerc / 100);
                    }
                    else if (i.PartyPhysicalDefPerc > 0)
                    {
                        FinalDamage = FinalDamage * (1 - i.PartyPhysicalDefPerc / 100);
                    }
                    else if (i.PartyFlatDefPerc > 0)
                    {
                        FinalDamage = FinalDamage * (1 - i.PartyFlatDefPerc / 100);
                    }
                    else if (i.Shield > 0)
                    {
                        FinalDamage = AttackDamage * (1 - i.Shield / 100);
                    }
                }
                //If its dark dmg.
                //This includes Mits like Passage of Arms
                else
                {
                    if (i.Shield > 0)
                    {
                        FinalDamage = AttackDamage * (1 - i.Shield / 100);
                    }
                }

            }
            // falta una variable en attack que sea el "requisito" para sobrevivir

            this.DoISurvive = this.Attack.Tier.GetMinDmg() > FinalDamage;
            //My partner is stupid:
            this.HpLeft = 0-(FinalDamage - this.Attack.Tier.GetMinDmg());
            
        }

    }
}
