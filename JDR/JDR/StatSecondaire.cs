using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class StatSecondaire : Stat
    {


        public override int GetValue(Perso perso)
        {
            //return (int)Math.Round(perso.race.stat[this.id] + perso.dée[this.id] + perso.sousRace.stat[this.id] + perso.bonusClasse[this.id] + perso.histoire.stat[this.id]);
            return 0;
        }
    }
}
