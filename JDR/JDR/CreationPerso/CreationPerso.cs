using JDR.BDD;
using JDR.Outil;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JDR.BDD.GestionBDD;

namespace JDR.CreationPerso
{
    class CreationPerso
    {
        public int CreatNewPerso(int idRace , int idClasse , int idSousRace , int lvl,String nom,String prenom , String description)
        {
            int idPerso = -1;
            GestionBDD conn = new GestionBDD();
            // getStatRace 
            DataTable tStatRace = conn.GetStatRaceByID(idRace);
            DataRow[] statsRace = tStatRace.Select();
            DicoInt stats = RandDicePerso(statsRace);

            DataTable tPerso = conn.GetPersos();
            DataRow[] rowPerso = tPerso.Select();
            String idtmp = rowPerso[rowPerso.Count()-1]["id"].ToString();

            Int32.TryParse(idtmp, out idPerso);
            idPerso++;
            DataRow perso = tPerso.NewRow();
            perso["id"] = idPerso;
            perso["race"] = idRace;
            perso["sousrace"] = idSousRace;
            perso["classe"] = idClasse;
            perso["vivant"] = true;
            perso["armedefaut"] = 0;
            perso["niveau"] = lvl;
            perso["nom"] = nom;
            perso["prenom"] = prenom;
            perso["definition"] = description;
            tPerso.Rows.Add(perso);


            conn.SubmitDataSetChanges("perso");

            DataTable tStatPerso = conn.GetStatPersoByID(idPerso);
            DataRow[] rowStatPerso = tStatPerso.Select();
            foreach (DataRow row in rowStatPerso)
            {
                row.Delete();
            }
            foreach(int idStat in stats.Keys)
            {
                DataRow newStat = tStatPerso.NewRow();
                newStat["id_stat"] = idStat;
                newStat["id_perso"] = idPerso;
                newStat["valeur"] = stats[idStat];
                tStatPerso.Rows.Add(newStat);
            }

            conn.SubmitDataSetChanges("statperso");

            return idPerso;
        }

        public DicoInt RandDicePerso(DataRow[] statsRace)
        {
            DicoInt stats = new DicoInt();
            foreach(DataRow row in statsRace)
            {
                int taille = -1;
                int nb = -1;
                int id = -1;
                Int32.TryParse(row["typedée"].ToString(),out taille);
                Int32.TryParse(row["NBDée"].ToString(), out nb);
                Int32.TryParse(row["id_stat"].ToString(), out id);
                int value = Roll.JetDée(taille, nb);
                stats.Add(id, value);
            }
            return stats;

        }



    }
}
