using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using JDR.Outil;

namespace JDR
{
    class StatCalculé : Stat
    {
        public List<int> statUtile;

        public override int GetValue(Perso perso)
        {
            float total = 0;
            foreach(int id in statUtile)
            {
                total += perso.listStat[id].GetValue(perso);
            }
            return GestionValeur.GetValeur(total);// (int)Math.Round(total + perso.race.stat[this.id] + perso.dée[this.id] + perso.sousRace.stat[this.id] + perso.bonusClasse[this.id] + perso.histoire.stat[this.id]);
        }

        public override int GetValueForTest(Perso perso)
        {
            float total = 0;
            foreach (int id in statUtile)
            {
                total += perso.listStat[id].GetValue(perso);
            }
            return GestionValeur.GetValeurOn100(total) ;
        }
    }
}
