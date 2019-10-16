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
    class Perso
    {
        public int id;
        public String nom;
        public String prenom;
        public Race race;
        public SousRace sousRace;
        public Classe classe;
        public DicoFloat bonusClasse;
        public Histoire histoire;
        public DicoFloat listStat;
        public DicoFloat buffDebuff;
        public List<Classe> evolution;
        private GestionBDD bdd;

        public Perso()
        {
            bdd = new GestionBDD();
        }

        private void GetPerso()
        {

            // recup les info du perso 
            int idRace = 0;
            int idSousRace;
            List<int> idCarriere;
            int idCurrentClasse;
            DicoFloat raceStat;
            DicoFloat sousRaceStat;
            DicoFloat classeStat;
            DicoFloat deeStat;

            // recup les stat de sa race
            DataTable tRace = bdd.GetRaceById(idRace);

            // recup les stat de sa sous race 

            // recup les stat de ses dée

            // recup les stat de ses carrière

            // recup les stat de son histoire

            // recup sont équipement 

            // recup sont inventaire

            // recup ses blessure grave 

            // lance le calcule des stat

        }

        public void LvlUp(Classe prochaineClasse)
        {
            foreach(int idStat in prochaineClasse.stat.Keys)
            {
                if (!bonusClasse.ContainsKey(idStat))
                {
                    bonusClasse.Add(idStat, 0);
                }
                bonusClasse[idStat] = bonusClasse[idStat] + prochaineClasse.stat[idStat];
            }
            this.classe = prochaineClasse;
        }



        public ResultatAttaque AttaqueCac(Perso cible)
        {
            return new ResultatAttaque(this, cible,"cac");
        }
        public ResultatAttaque AttaqueDist(Perso cible)
        {
            return new ResultatAttaque(this, cible, "dist");
        }

        public Boolean JetStat(int idStat , int bonus , out float objectif , out int resultat)
        {
            Boolean reussite;
            Roll.Jet100(listStat[idStat] + bonus ,out resultat, out reussite);
            objectif = listStat[idStat];
            return reussite;
        }


    }

}
