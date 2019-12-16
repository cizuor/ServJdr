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
    public class Materiel
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
        public DicoInt stat;
        private GestionBDD bdd;

        public Materiel(int id)
        {
            bdd = new GestionBDD();

            DataTable tMateriel = bdd.GetMaterielById(id);
            DataRow[] drMateriel = tMateriel.Select();
            this.poid = Int32.Parse(drMateriel[0]["poid"].ToString());
            this.prix = Int32.Parse(drMateriel[0]["prix"].ToString());
            this.nom = drMateriel[0]["nom"].ToString();
            this.definition = drMateriel[0]["definition"].ToString();
            this.typeDée = Int32.Parse(drMateriel[0]["typedee"].ToString());
            this.nbDée = Int32.Parse(drMateriel[0]["nbdee"].ToString());
            this.damage = Int32.Parse(drMateriel[0]["dommage"].ToString());
            this.baseDamage = Int32.Parse(drMateriel[0]["basedommage"].ToString());
            this.ratioF = Int32.Parse(drMateriel[0]["ratiof"].ToString());
            this.ratioAg = Int32.Parse(drMateriel[0]["ratioag"].ToString());
            this.ratioInt = Int32.Parse(drMateriel[0]["ratioint"].ToString());
            this.armureBase = Int32.Parse(drMateriel[0]["armurebase"].ToString());
            this.rmBase = Int32.Parse(drMateriel[0]["rmbase"].ToString());
            this.armureBonus = Int32.Parse(drMateriel[0]["armurebonus"].ToString());
            this.rmBonus = Int32.Parse(drMateriel[0]["rmbonus"].ToString());
            this.degatcrit = Int32.Parse(drMateriel[0]["dcrit"].ToString());
            this.pSort = Int32.Parse(drMateriel[0]["psort"].ToString());
            DataTable tStatMateriel = bdd.GetStatMaterielByID(id);
            DataRow[] statsMateriel = tStatMateriel.Select();
            stat = new DicoInt();

            foreach (DataRow row in statsMateriel)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                int valeur = Int32.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }
        }


    }

}

