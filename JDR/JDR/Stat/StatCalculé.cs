using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                total += perso.listStat[id];
            }



            return 0;// (int)Math.Round(total + perso.race.stat[this.id] + perso.dée[this.id] + perso.sousRace.stat[this.id] + perso.bonusClasse[this.id] + perso.histoire.stat[this.id]);

        }
    }
}
