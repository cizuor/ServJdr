using JDR.Outil;
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
            float total = (float)Math.Round((perso.race.stat[this.id] + perso.sousRace.stat[this.id] + perso.autreStat[this.id]) * perso.classe.stat[this.id] + perso.histoire.stat[this.id]);
            return GestionValeur.GetValeur(total);
        }

        public override int GetValueForTest(Perso perso)
        {
            float total = (float)Math.Round((perso.race.stat[this.id] + perso.sousRace.stat[this.id] + perso.autreStat[this.id]) * perso.classe.stat[this.id] + perso.histoire.stat[this.id]);
            return GestionValeur.GetValeurOn100(total);
        }
    }
}
