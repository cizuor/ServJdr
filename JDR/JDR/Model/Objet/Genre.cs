﻿using JDR.BDD;
using JDR.Model.Action;
using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    public class Genre
    {
        public int id;
        public String nom;
        public String definition;
        public int poid;
        public int prix;
        public int typeEquipement;
        public int typeObjet;
        public int damage;
        public int armureBase;
        public int rmBase;
        public int armureBonus;
        public int rmBonus;
        public Boolean loot;
        public int degatcrit;
        public int pSort;
        public int nbMains;
        public int pMin;
        public int pMax;
        public int chancecrit;
        public DicoInt stat;
        private GestionBDD bdd;
        public List<Effet> effets;

        public Genre(int id)
        {
            bdd = new GestionBDD();

            DataTable tGenre = bdd.GetGenreById(id);
            DataRow[] drGenre = tGenre.Select();
            this.poid = Int32.Parse(drGenre[0]["poid"].ToString());
            this.prix = Int32.Parse(drGenre[0]["prix"].ToString());
            this.typeEquipement = Int32.Parse(drGenre[0]["typequip"].ToString());
            this.typeObjet = Int32.Parse(drGenre[0]["type"].ToString());
            this.nom = drGenre[0]["nom"].ToString();
            this.definition = drGenre[0]["definition"].ToString();
            this.damage = Int32.Parse(drGenre[0]["dommage"].ToString());
            this.armureBase = Int32.Parse(drGenre[0]["armurebase"].ToString());
            this.rmBase = Int32.Parse(drGenre[0]["rmbase"].ToString());
            this.armureBonus = Int32.Parse(drGenre[0]["armurebonus"].ToString());
            this.rmBonus = Int32.Parse(drGenre[0]["rmbonus"].ToString());
            this.loot = Boolean.Parse(drGenre[0]["loot"].ToString());
            this.degatcrit = Int32.Parse(drGenre[0]["dcrit"].ToString());
            this.pSort = Int32.Parse(drGenre[0]["psort"].ToString());
            this.nbMains = Int32.Parse(drGenre[0]["nbmains"].ToString());
            this.pMin = Int32.Parse(drGenre[0]["portermin"].ToString());
            this.pMax = Int32.Parse(drGenre[0]["portermax"].ToString());
            this.chancecrit = Int32.Parse(drGenre[0]["chanccrit"].ToString());
            DataTable tStatGenre = bdd.GetStatGenreByID(id);
            DataRow[] statsGenre = tStatGenre.Select();
            stat = new DicoInt();

            foreach (DataRow row in statsGenre)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                int valeur = Int32.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }


            DataTable tEffetGenre = bdd.GetEffetGenreByID(id);
            DataRow[] drEffetGenre = tEffetGenre.Select();
            effets = new List<Effet>();

            foreach (DataRow row in drEffetGenre)
            {
                effets.Add( new Effet(Int32.Parse(row["id_effet"].ToString())));
            }

        }

        public enum typeEquipementBase
        {
            cac = 1,
            dist = 2,
            armure = 3,
            bouclier = 4,
        }
        public enum TypeObjet
        {
            Utilitaire = 0,
            Consommable = 1,
            Equipement = 2,
            Composant = 3
        }
    }

    

}
