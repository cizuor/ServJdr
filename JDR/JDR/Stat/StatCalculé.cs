using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.Outil;

namespace JDR
{
    class StatCalculé : Stat
    {
        public List<int> statUtile;

        public override int GetValue(Perso perso)
        {
             return GestionValeur.GetValeur(CalculeStat(perso));// (int)Math.Round(total + perso.race.stat[this.id] + perso.dée[this.id] + perso.sousRace.stat[this.id] + perso.bonusClasse[this.id] + perso.histoire.stat[this.id]);
        }

        public override int GetValueForTest(Perso perso)
        {
            return GestionValeur.GetValeurOn100(CalculeStat(perso)) ;
        }

        protected override float CalculeStat(Perso perso)
        {
            float total = 0;
            foreach (int id in statUtile)
            {
                total += perso.listStat[id].GetValue(perso);
            }
            total += (float)Math.Round((perso.race.stat[this.id] + perso.sousRace.stat[this.id] + perso.autreStat[this.id]) + (perso.classe.stat[this.id] * perso.lvl) + perso.histoire.stat[this.id] + perso.buffDebuff[this.id]);
            return total;
        }
    }
}
