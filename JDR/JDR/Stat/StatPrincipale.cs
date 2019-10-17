using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class StatPrincipale : Stat
    {

        public override int GetValue(Perso perso)
        {
            return GestionValeur.GetValeur(CalculeStat(perso));
        }

        public override int GetValueForTest(Perso perso)
        {
            return GestionValeur.GetValeurOn100(CalculeStat(perso));
        }

        public override float CalculeStat(Perso perso)
        {
            return (float)Math.Round((perso.race.stat[this.id] + perso.sousRace.stat[this.id] + perso.autreStat[this.id]) * (1 + perso.classe.stat[this.id] * perso.lvl) + perso.histoire.stat[this.id]);

        }
    }
}
