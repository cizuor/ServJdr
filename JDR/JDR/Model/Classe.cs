using JDR.BDD;
using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class Classe
    {
        public GestionBDD bdd;
        public int id;
        public String nom;
        public String description;
        public DicoFloat stat;

        public Classe(int id)
        {
            bdd = new GestionBDD();
            DataTable tClasse = bdd.GetRaceById(id);
            this.id = id;
            DataRow[] rowClasse = tClasse.Select();
            this.nom = rowClasse[0]["nom"].ToString();
            this.description = rowClasse[0]["definition"].ToString();
            DataTable tStatClasse = bdd.GetStatRaceByID(id);
            DataRow[] statsClasse = tStatClasse.Select();
            stat = new DicoFloat();

            foreach (DataRow row in statsClasse)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                float valeur = float.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }
        }
    }
}
