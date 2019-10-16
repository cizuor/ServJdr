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
    class Race
    {
        private GestionBDD bdd;
        public int id;
        public String nom;
        public String description;
        public DicoFloat stat;
        public Dictionary<String, String> dée;


        public Race (int id)
        {
            bdd = new GestionBDD();
            DataTable tRace = bdd.GetRaceById(id);
            this.id = id;
            DataRow[] rowrace = tRace.Select();
            this.nom = rowrace[0]["nom"].ToString();
            this.description = rowrace[0]["definition"].ToString();
            DataTable tStatRace = bdd.GetStatRaceByID(id);
            DataRow[] statsRace = tStatRace.Select();
            stat = new DicoFloat();

            foreach (DataRow row in statsRace)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                float valeur = float.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }
        }


        
    }
}
