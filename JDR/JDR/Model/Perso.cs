using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.BDD;
using JDR.Model.Objet;
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
        public DicoBuff buffDebuff;
        private GestionBDD bdd;
        public Dictionary<int, Stat> listStat;// liste de toute les stat du jeux 
        public List<Items> inventaire;
        public List<Equipement> listEquipement;
        public List<Utilitaire> Utilitaire;
        public int positionX;
        public int positionY;
        public int MouvementRestant;
        public int PARestant;
        public int numEquipe;

        public Perso()
        {
            bdd = new GestionBDD();
        }

        public Perso(int id)
        {
            bdd = new GestionBDD();
            buffDebuff = new DicoBuff();
            histoire = new Histoire();
            DataTable tPerso = bdd.GetPersoById(id);
            DataRow[] drPerso = tPerso.Select();
            int idRace = Int32.Parse( drPerso[0]["race"].ToString());
            int idSousRace = Int32.Parse(drPerso[0]["sousrace"].ToString());
            int idClasse = Int32.Parse(drPerso[0]["classe"].ToString());
            listEquipement = new List<Equipement>();
            inventaire = new List<Items>();
            this.id = id;
            nom = drPerso[0]["nom"].ToString();
            prenom = drPerso[0]["prenom"].ToString();
            definition = drPerso[0]["definition"].ToString();
            lvl = Int32.Parse(drPerso[0]["niveau"].ToString());
            vivant = Boolean.Parse(drPerso[0]["vivant"].ToString());
            // recup les info du perso 

            race = new Race(idRace); // récup toute les donné de sa race 
            sousRace = new SousRace(idSousRace);// récup toute les donné de sa sousrace 
            classe = new Classe(idClasse);// récup toute les donné de sa classe 

            InitAllStat();

            DataTable tStatPerso = bdd.GetStatPersoByID(id);
            DataRow[] drStatPerso = tStatPerso.Select();
            foreach(DataRow statPerso in drStatPerso)
            {
                int idstat = Int32.Parse(statPerso[0].ToString());
                int value = Int32.Parse(statPerso[2].ToString());
                listStat[idstat].valeur = value;
            }


            DataTable tObjetPerso = bdd.GetObjetPersoByID(id);
            DataRow[] drObjetPerso = tObjetPerso.Select();
            foreach (DataRow objPerso in drObjetPerso)
            {
                int idobjet = Int32.Parse(objPerso[0].ToString());
                Boolean isEquipe = Boolean.Parse(objPerso[2].ToString());
                int type;
                Items item = Items.GetItems(idobjet, out type);
                if (isEquipe)
                {
                    if(type == 2)
                    {
                        listEquipement.Add((Equipement)item);
                    }
                }
                else
                {
                    inventaire.Add(item);
                }
            }
            // recup sont équipement 

            // recup sont inventaire

            // recup ses blessure grave 

            // lance le calcule des stat

            int CC = listStat[0].GetValue();

        }

        private void InitAllStat()
        {
            DataTable tStat = bdd.GetStat();
            DataRow[] drStats = tStat.Select();
            listStat = new Dictionary<int, Stat>();
            foreach (DataRow stat in drStats)
            {
                int type = Int32.Parse(stat[3].ToString());
                int idstat = Int32.Parse(stat[0].ToString());
                String nom = stat[1].ToString();
                String description = stat[2].ToString();
                if (type == 0)
                {
                    listStat.Add(idstat, new StatPrincipale(idstat, 0, nom, description,this));
                }
                else if (type == 1)
                {
                    listStat.Add(idstat, new StatSecondaire(idstat, 0, nom, description, this));
                }
                else if (type == 2)
                {
                    listStat.Add(idstat, new StatCalculé(idstat, 0, nom, description, this));
                }
            }
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
            objectif = listStat[idStat].GetValue() + bonus;
            Roll.Jet100(objectif ,out resultat, out reussite);
            
            return reussite;
        }


        public Boolean NewTour()
        {
            PARestant = listStat[(int)Stat.stats.PointAction].GetValue();
            return true;
        }




        public Boolean Deplacement(int x , int y)
        {
            int dist = Math.Abs(x - positionX) + Math.Abs(y - positionY);
            if (dist < MouvementRestant)
            {
                MouvementRestant = MouvementRestant - dist;
                positionX = x;
                positionY = y;
                return true;
            }
            return false;
        }




    }

}
