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
        public String definition;
        public Boolean vivant;
        public Race race;
        public SousRace sousRace;
        public Classe classe;
        public int lvl;
        public Histoire histoire;
        public DicoFloat autreStat;// dées et bonnus lier au lvl
        public DicoFloat buffDebuff;
        private GestionBDD bdd;
        public Dictionary<int, Stat> listStat;// liste de toute les stat du jeux 

        public Perso()
        {
            bdd = new GestionBDD();
        }

        private Perso(int id)
        {
            bdd = new GestionBDD();
            DataTable tPerso = bdd.GetPersoById(id);
            DataRow[] drPerso = tPerso.Select();
            int idRace = Int32.Parse( drPerso[0]["race"].ToString());
            int idSousRace = Int32.Parse(drPerso[0]["sousrace"].ToString());
            int idClasse = Int32.Parse(drPerso[0]["classe"].ToString());
            nom = drPerso[0]["nom"].ToString();
            prenom = drPerso[0]["prenom"].ToString();
            definition = drPerso[0]["definition"].ToString();
            lvl = Int32.Parse(drPerso[0]["niveau"].ToString());
            vivant = Boolean.Parse(drPerso[0]["vivant"].ToString());
            // recup les info du perso 

            race = new Race(idRace);
            sousRace = new SousRace(idSousRace);
            classe = new Classe(idClasse);

            List<int> idCarriere;
            int idCurrentClasse;
            DicoFloat raceStat;
            DicoFloat sousRaceStat;
            DicoFloat classeStat;
            DicoFloat deeStat;

            // recup les stat de sa race
            

            // recup les stat de sa sous race 

            // recup les stat de ses dée

            // recup les stat de ses carrière

            // recup les stat de son histoire

            // recup sont équipement 

            // recup sont inventaire

            // recup ses blessure grave 

            // lance le calcule des stat

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
            objectif = listStat[idStat].GetValue(this) + bonus;
            Roll.Jet100(objectif ,out resultat, out reussite);
            
            return reussite;
        }


    }

}
