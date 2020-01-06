using JDR.BDD;
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
        public int typeDée;
        public int nbDée;
        public int damage;
        public int baseDamage;
        public int ratioF;
        public int ratioAg;
        public int ratioInt;
        public int armureBase;
        public int rmBase;
        public int armureBonus;
        public int rmBonus;
        public int degatcrit;
        public int pSort;
        public int duree;
        public int chancecrit;
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
            this.typeDée = Int32.Parse(drQualite[0]["typedee"].ToString());
            this.nbDée = Int32.Parse(drQualite[0]["nbdee"].ToString());
            this.damage = Int32.Parse(drQualite[0]["dommage"].ToString());
            this.baseDamage = Int32.Parse(drQualite[0]["basedommage"].ToString());
            this.ratioF = Int32.Parse(drQualite[0]["ratiof"].ToString());
            this.ratioAg = Int32.Parse(drQualite[0]["ratioag"].ToString());
            this.ratioInt = Int32.Parse(drQualite[0]["ratioint"].ToString());
            this.armureBase = Int32.Parse(drQualite[0]["armurebase"].ToString());
            this.rmBase = Int32.Parse(drQualite[0]["rmbase"].ToString());
            this.armureBonus = Int32.Parse(drQualite[0]["armurebonus"].ToString());
            this.rmBonus = Int32.Parse(drQualite[0]["rmbonus"].ToString());
            this.degatcrit = Int32.Parse(drQualite[0]["dcrit"].ToString());
            this.pSort = Int32.Parse(drQualite[0]["psort"].ToString());
            this.duree = Int32.Parse(drQualite[0]["duree"].ToString());
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
        }
    }
}
