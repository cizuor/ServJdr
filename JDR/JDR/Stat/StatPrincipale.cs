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
        public StatPrincipale(int id, int valeur, string nom, string description , Perso perso) : base(id, valeur, nom, description , perso)
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
            int tmp = perso.classe.stat[this.id] * perso.lvl;
            int tmp2 = perso.race.stat[this.id] + perso.sousRace.stat[this.id] + valeur;
            int tmp3 = (perso.race.stat[this.id] + perso.sousRace.stat[this.id] + valeur) * (1 + perso.classe.stat[this.id] * perso.lvl);


            return ((perso.race.stat[this.id] + perso.sousRace.stat[this.id] + valeur) * (100 + perso.classe.stat[this.id] * perso.lvl))/100 + perso.histoire.stat[this.id] + perso.buffDebuff[this.id].valeur;

        }
    }
}
