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
    class SousRace
    {
        public int id;
        public String nom;
        public String description;
        public DicoInt stat;
        private GestionBDD bdd;


        public SousRace(int id)
        {
            bdd = new GestionBDD();
            DataTable tSousRace = bdd.GetSousRaceById(id);
            this.id = id;
            DataRow[] rowrace = tSousRace.Select();
            this.nom = rowrace[0]["nom"].ToString();
            this.description = rowrace[0]["definition"].ToString();
            DataTable tStatSousRace = bdd.GetStatSousRaceByID(id);
            DataRow[] statsSousRace = tStatSousRace.Select();
            stat = new DicoInt();

            foreach (DataRow row in statsSousRace)
            {
                int idstat = Int32.Parse(row["id_stat"].ToString());
                int valeur = Int32.Parse(row["valeur"].ToString());
                stat.Add(idstat, valeur);
            }
        }
    }
}
