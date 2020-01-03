using JDR.Model.Objet;
using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{/// <summary>
/// les stat qui ne sont pas multiplicative , critique , PA , PM ....
/// </summary>
    class StatSecondaire : Stat
    {
        public StatSecondaire(int id, int valeur, string nom, string description , Perso perso) : base(id, valeur, nom, description, perso)
        {
        }

        public override int GetValue()
        {
            return GestionValeur.GetValeur(CalculeStat());
        }

        public override int GetValueForTest()
        {
            return GestionValeur.GetValeurOn100(CalculeStat());
        }

        protected override int CalculeStat()
        {

            int bonusEquip = 0;
            foreach (Equipement equip in perso.listEquipement)
            {
                bonusEquip += equip.GetStat(id);
            }

            return (perso.race.stat[this.id] + perso.sousRace.stat[this.id] + valeur) + (perso.classe.stat[this.id] * perso.lvl) + perso.histoire.stat[this.id] + perso.buffDebuff[this.id].valeur + bonusEquip;

        }
    }
}
