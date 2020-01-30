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
    public class Materiel
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
        public DicoInt stat;
        public List<Effet> effets;
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
            this.damage = Int32.Parse(drMateriel[0]["dommage"].ToString());
            this.armureBase = Int32.Parse(drMateriel[0]["armurebase"].ToString());
            this.rmBase = Int32.Parse(drMateriel[0]["rmbase"].ToString());
            this.armureBonus = Int32.Parse(drMateriel[0]["armurebonus"].ToString());
            this.rmBonus = Int32.Parse(drMateriel[0]["rmbonus"].ToString());
            this.degatcrit = Int32.Parse(drMateriel[0]["dcrit"].ToString());
            this.pSort = Int32.Parse(drMateriel[0]["psort"].ToString());
            this.chancecrit = Int32.Parse(drMateriel[0]["chanccrit"].ToString());
            DataTable tStatMateriel = bdd.GetStatMaterielByID(id);
            DataRow[] statsMateriel = tStatMateriel.Select();
            stat = new DicoInt();

            foreach (DataRow row in statsMateriel)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                int valeur = Int32.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }


            DataTable tEffetMateriel = bdd.GetEffetMaterielByID(id);
            DataRow[] drEffetMateriel = tEffetMateriel.Select();
            effets = new List<Effet>();

            foreach (DataRow row in drEffetMateriel)
            {
                effets.Add(new Effet(Int32.Parse(row["id_effet"].ToString())));
            }
        }


    }

}

