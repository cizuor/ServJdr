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


        public Boolean ExecuteQuery(String table , String sql)
        {
            if (!dicData.ContainsKey(table))
            {
                dicData.Add(table, new DataConn());
            }
            return conn.ExecuteQuery(sql, out dicData[table].ds, out dicData[table].da);
        }




        public DataTable GetStat()
        {
            if (!dicData.ContainsKey("stat"))
            {
                dicData.Add("stat", new DataConn());
            }
            return conn.GetTable("stat", out dicData["stat"].ds, out dicData["stat"].da);
        }



        public DataTable GetStatCalculer(int id)
        {
            if (!dicData.ContainsKey("statcalculer"))
            {
                dicData.Add("statcalculer", new DataConn());
            }
            return conn.GetStatCalculé(id, out dicData["statcalculer"].ds, out dicData["statcalculer"].da);
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
                dicData.Add("statclasse", new DataConn());
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


        public DataTable GetPersoById(int id)
        {
            if (!dicData.ContainsKey("perso"))
            {
                dicData.Add("perso", new DataConn());
            }
            return conn.GetLigneFromTable("perso", id, out dicData["perso"].ds, out dicData["perso"].da);
        }

        /*public Boolean GetPersoById(int id)
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
        }*/

        public DataTable GetStatPersoByID(int id)
        {
            if (!dicData.ContainsKey("statperso"))
            {
                dicData.Add("statperso", new DataConn());
            }

            return conn.GetStatFrom("perso", id, out dicData["statperso"].ds, out dicData["statperso"].da);
        }

        public DataTable GetObjetPersoByID(int id)
        {
            if (!dicData.ContainsKey("objetperso"))
            {
                dicData.Add("objetperso", new DataConn());
            }
            return conn.GetJointureFrom("perso", "objet", id, out dicData["objetperso"].ds, out dicData["objetperso"].da);
        }

        public DataTable GetObjetsPerso()
        {
            if (!dicData.ContainsKey("objetperso"))
            {
                dicData.Add("objetperso", new DataConn());
            }
            return conn.GetTable("objetperso", out dicData["objetperso"].ds, out dicData["objetperso"].da);
        }




        public DataTable GetItems()
        {
            if (!dicData.ContainsKey("objet"))
            {
                dicData.Add("objet", new DataConn());
            }
            return conn.GetTable("objet", out dicData["objet"].ds, out dicData["objet"].da);
        }

        public DataTable GetItemById(int id)
        {
            if (!dicData.ContainsKey("objet"))
            {
                dicData.Add("objet", new DataConn());
            }
            return conn.GetLigneFromTable("objet", id, out dicData["objet"].ds, out dicData["objet"].da);
        }

        public DataTable GetGenre()
        {
            if (!dicData.ContainsKey("genre"))
            {
                dicData.Add("genre", new DataConn());
            }
            return conn.GetTable("genre", out dicData["genre"].ds, out dicData["genre"].da);
        }

        public DataTable GetGenreById(int id)
        {
            if (!dicData.ContainsKey("genre"))
            {
                dicData.Add("genre", new DataConn());
            }
            return conn.GetLigneFromTable("genre", id, out dicData["genre"].ds, out dicData["genre"].da);
        }

        public DataTable GetStatGenreByID(int id)
        {
            if (!dicData.ContainsKey("statgenre"))
            {
                dicData.Add("statgenre", new DataConn());
            }
            return conn.GetStatFrom("genre", id, out dicData["statgenre"].ds, out dicData["statgenre"].da);
        }


        public DataTable GetMateriel()
        {
            if (!dicData.ContainsKey("materiel"))
            {
                dicData.Add("materiel", new DataConn());
            }
            return conn.GetTable("materiel", out dicData["materiel"].ds, out dicData["materiel"].da);
        }

        public DataTable GetMaterielById(int id)
        {
            if (!dicData.ContainsKey("materiel"))
            {
                dicData.Add("materiel", new DataConn());
            }
            return conn.GetLigneFromTable("materiel", id, out dicData["materiel"].ds, out dicData["materiel"].da);
        }

        public DataTable GetStatMaterielByID(int id)
        {
            if (!dicData.ContainsKey("statmateriel"))
            {
                dicData.Add("statmateriel", new DataConn());
            }
            return conn.GetStatFrom("materiel", id, out dicData["statmateriel"].ds, out dicData["statmateriel"].da);
        }


        public DataTable GetQualite()
        {
            if (!dicData.ContainsKey("qualite"))
            {
                dicData.Add("qualite", new DataConn());
            }
            return conn.GetTable("qualite", out dicData["qualite"].ds, out dicData["qualite"].da);
        }

        public DataTable GetQualiteById(int id)
        {
            if (!dicData.ContainsKey("qualite"))
            {
                dicData.Add("qualite", new DataConn());
            }
            return conn.GetLigneFromTable("qualite", id, out dicData["qualite"].ds, out dicData["qualite"].da);
        }

        public DataTable GetStatQualiteByID(int id)
        {
            if (!dicData.ContainsKey("statqualite"))
            {
                dicData.Add("statqualite", new DataConn());
            }
            return conn.GetStatFrom("qualite", id, out dicData["statqualite"].ds, out dicData["statqualite"].da);
        }



        public DataTable GetActionById(int id)
        {
            if (!dicData.ContainsKey("action"))
            {
                dicData.Add("action", new DataConn());
            }
            return conn.GetLigneFromTable("action", id, out dicData["action"].ds, out dicData["action"].da);
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

        /// <summary>
        /// trouve l'objet et lui met la valeur de isEquipe dans le bollean d'équipement
        /// </summary>
        /// <param name="idPerso"></param>
        /// <param name="idObjet"></param>
        /// <param name="isEquipe"></param>
        /// <returns></returns>
        public Boolean GestionEquipement(int idPerso , int idObjet , Boolean isEquipe)
        {
            DataTable tItemPerso = GetObjetsPerso();
            DataRow[] rowItems = tItemPerso.Select("id_objet = '" + idObjet + "' and id_perso = '" + idPerso + "' ");
            foreach(DataRow row in rowItems)
            {
                if(Int32.Parse(row["id_objet"].ToString()) == idObjet)
                {
                    row["isequipe"] = isEquipe;
                    this.SubmitDataSetChanges("objetperso");
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// si l'objet est loot alors le rajoute sinon le suprime 
        /// </summary>
        /// <param name="idPerso"></param>
        /// <param name="idObjet"></param>
        /// <param name="isLoot"></param>
        /// <returns></returns>
        public Boolean GestionLoot(int idPerso, int idObjet, Boolean isLoot)
        {
            DataTable tItemPerso = GetObjetsPerso();
            DataRow[] rowItems = tItemPerso.Select("id_objet = '" + idObjet + "' and id_perso = '" + idPerso + "' ");
            if (isLoot)
            {
                foreach (DataRow row in rowItems)
                {
                    if (Int32.Parse(row["id_objet"].ToString()) == idObjet) // l'objet est déja dans l'inventaire
                    {
                        return false ;
                    }
                }
                DataRow item = tItemPerso.NewRow();
                item["id_objet"] = idObjet;
                item["id_perso"] = idPerso;
                item["isequipe"] = false;
                tItemPerso.Rows.Add(item);
                this.SubmitDataSetChanges("objetperso");
                return true;
            }
            else
            {
                foreach (DataRow row in rowItems)
                {
                    if (Int32.Parse(row["id_objet"].ToString()) == idObjet)
                    {
                        tItemPerso.Rows.Remove(row);
                        this.SubmitDataSetChanges("objetperso");
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
