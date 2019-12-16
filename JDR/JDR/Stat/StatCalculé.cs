using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.BDD;
using JDR.Outil;

namespace JDR
{
    class StatCalculé : Stat
    {
        public Dictionary<int,int> statUtile;
        public StatCalculé(int id, int valeur, string nom, string description ,Perso perso) : base(id, valeur, nom, description , perso)
        {
            statUtile = new Dictionary<int, int>();
            GestionBDD bdd = new GestionBDD();
            DataTable tStatCalculer =  bdd.GetStatCalculer(id);
            DataRow[] drStatCalculer = tStatCalculer.Select();
            foreach(DataRow statcalculer in drStatCalculer)
            {
                statUtile.Add(Int32.Parse(statcalculer[1].ToString()), Int32.Parse(statcalculer[2].ToString()));
            }
        }


        public override int GetValue()
        {
             return GestionValeur.GetValeur(CalculeStat());// (int)Math.Round(total + perso.race.stat[this.id] + perso.dée[this.id] + perso.sousRace.stat[this.id] + perso.bonusClasse[this.id] + perso.histoire.stat[this.id]);
        }

        public override int GetValueForTest()
        {
            return GestionValeur.GetValeurOn100(CalculeStat()) ;
        }

        protected override int CalculeStat()
        {
            int total = 0;
            foreach (int id in statUtile.Keys)
            {
                total += (perso.listStat[id].GetValue() * (statUtile[id]))/100;
            }
            total += (perso.race.stat[this.id] + perso.sousRace.stat[this.id] + valeur) + (perso.classe.stat[this.id] * perso.lvl) + perso.histoire.stat[this.id] + perso.buffDebuff[this.id].valeur;
            return total;
        }
    }
}
