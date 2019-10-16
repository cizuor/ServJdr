using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.BDD
{
    public class GestionBDD
    {
        public Dictionary<String, DataConn> dicData;
        private Connection conn;

        public GestionBDD()
        {
            conn = Connection.GetConnection();
            dicData = new Dictionary<string, DataConn>();
        }

        public DataTable GetRaces()
        {
            if (!dicData.ContainsKey("race"))
            {
                dicData.Add("race", new DataConn());
            }
            return conn.GetTable("race", out dicData["race"].ds, out dicData["race"].da);
        }

        public DataTable GetRaceById(int id)
        {
            if (!dicData.ContainsKey("race"))
            {
                dicData.Add("race", new DataConn());
            }
            return conn.GetLigneFromTable("race", id, out dicData["race"].ds, out dicData["race"].da);
        }


        public DataTable GetStatRaceByID(int id)
        {
            if (!dicData.ContainsKey("statrace"))
            {
                dicData.Add("statrace", new DataConn());
            }
            return conn.GetStatFrom("race", id, out dicData["statrace"].ds, out dicData["statrace"].da);
        }



        public DataTable GetSousRaces()
        {
            if (!dicData.ContainsKey("sousrace"))
            {
                dicData.Add("sousrace", new DataConn());
            }
            return conn.GetTable("sousrace", out dicData["sousrace"].ds, out dicData["sousrace"].da);
        }

        public DataTable GetSousRaceById(int id)
        {
            if (!dicData.ContainsKey("sousrace"))
            {
                dicData.Add("sousrace", new DataConn());
            }
            return conn.GetLigneFromTable("sousrace", id, out dicData["sousrace"].ds, out dicData["sousrace"].da);
        }

        public DataTable GetSousRaceByRaceId(int id)
        {
            if (!dicData.ContainsKey("sousrace"))
            {
                dicData.Add("sousrace", new DataConn());
            }
            return conn.GetJointureFrom("race","sousrace", id, out dicData["sousrace"].ds, out dicData["sousrace"].da);
        }

        public DataTable GetStatSousRaceByID(int id)
        {
            if (!dicData.ContainsKey("statsousrace"))
            {
                dicData.Add("statsousrace", new DataConn());
            }

            return conn.GetStatFrom("sousrace", id, out dicData["statsousrace"].ds, out dicData["statsousrace"].da);
        }


        public DataTable GetClasses()
        {
            if (!dicData.ContainsKey("classe"))
            {
                dicData.Add("classe", new DataConn());
            }
            return conn.GetTable("classe", out dicData["classe"].ds, out dicData["classe"].da);
        }

        public DataTable GetClasseById(int id)
        {
            if (!dicData.ContainsKey("classe"))
            {
                dicData.Add("classe", new DataConn());
            }
            return conn.GetLigneFromTable("classe", id, out dicData["classe"].ds, out dicData["classe"].da);
        }
        public DataTable GetStatClasseByID(int id)
        {
            if (!dicData.ContainsKey("statclasse"))
            {
                dicData.Add("statclassejoin", new DataConn());
            }
            return conn.GetStatFrom("classe", id, out dicData["statclasse"].ds, out dicData["statclasse"].da);
        }


        public DataTable GetPersos()
        {
            if (!dicData.ContainsKey("perso"))
            {
                dicData.Add("perso", new DataConn());
            }
            return conn.GetTable("perso", out dicData["perso"].ds, out dicData["perso"].da);
        }

        public Boolean GetPersoById(int id)
        {
            DataSet ds = null;
            NpgsqlDataAdapter da = null;
            DataTable tPerso = conn.GetLigneFromTable("perso", id, out ds, out da);
            DataTable tRace;
            DataTable tClasse;
            DataRow[] rPerso = tPerso.Select();
            int idRace = -1;
            if (rPerso.Count() > 0 && Int32.TryParse(rPerso[0]["race"].ToString(),out idRace))
            {
                tRace = conn.GetLigneFromTable("race", idRace, out ds, out da);
            }
            int idClasse = -1;
            if (rPerso.Count() > 0 && Int32.TryParse(rPerso[0]["classe"].ToString(), out idClasse))
            {
                tClasse = conn.GetLigneFromTable("classe", idRace, out ds, out da);
            }
            // la même sur la sous race
            return true;
        }

        public DataTable GetStatPersoByID(int id)
        {
            if (!dicData.ContainsKey("statperso"))
            {
                dicData.Add("statperso", new DataConn());
            }

            return conn.GetStatFrom("perso", id, out dicData["statperso"].ds, out dicData["statperso"].da);
        }



        /// <summary>
        /// renvoi ta datatable demander 
        /// </summary>
        /// <param name="nomTable"></param>
        /// <returns></returns>
        public DataTable GetTable(String nomTable)
        {
            DataSet ds = null;
            NpgsqlDataAdapter da = null;
            return conn.GetTable(nomTable, out ds, out da);
        }


        public int SubmitDataSetChanges(String nomTable)
        {
            return conn.SubmitDataSetChanges(dicData[nomTable].da, dicData[nomTable].ds);
        }

        public class DataConn
        {
            public DataSet ds;
            public NpgsqlDataAdapter da;
        }

    }
}
