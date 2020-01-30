using JDR.BDD;
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
    public class Qualite
    {
        public int id;
        public String nom;
        public String definition;
        public int poid;
        public int prix;
        public int damage;
        public int armureBase;
        public int rmBase;
        public int armureBonus;
        public int rmBonus;
        public int degatcrit;
        public int pSort;
        public int chancecrit;
        public List<Effet> effets;
        public DicoInt stat;
        private GestionBDD bdd;

        public Qualite(int id)
        {
            bdd = new GestionBDD();

            DataTable tQualite = bdd.GetQualiteById(id);
            DataRow[] drQualite = tQualite.Select();
            this.poid = Int32.Parse(drQualite[0]["poid"].ToString());
            this.prix = Int32.Parse(drQualite[0]["prix"].ToString());
            this.nom = drQualite[0]["nom"].ToString();
            this.definition = drQualite[0]["definition"].ToString();
            this.damage = Int32.Parse(drQualite[0]["dommage"].ToString());
            this.armureBase = Int32.Parse(drQualite[0]["armurebase"].ToString());
            this.rmBase = Int32.Parse(drQualite[0]["rmbase"].ToString());
            this.armureBonus = Int32.Parse(drQualite[0]["armurebonus"].ToString());
            this.rmBonus = Int32.Parse(drQualite[0]["rmbonus"].ToString());
            this.degatcrit = Int32.Parse(drQualite[0]["dcrit"].ToString());
            this.pSort = Int32.Parse(drQualite[0]["psort"].ToString());
            this.chancecrit = Int32.Parse(drQualite[0]["chanccrit"].ToString());
            DataTable tStatQualite = bdd.GetStatQualiteByID(id);
            DataRow[] statsQualite = tStatQualite.Select();
            stat = new DicoInt();

            foreach (DataRow row in statsQualite)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                int valeur = int.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }

            DataTable tEffetQualite = bdd.GetEffetQualiteByID(id);
            DataRow[] drEffetQualite = tEffetQualite.Select();
            effets = new List<Effet>();

            foreach (DataRow row in drEffetQualite)
            {
                effets.Add(new Effet(Int32.Parse(row["id_effet"].ToString())));
            }

        }
    }
}
