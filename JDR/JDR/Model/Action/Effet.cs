using JDR.BDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Action
{
    public class Effet
    {
        private GestionBDD bdd;
        public int id;
        public String nom;
        public String definition;
        public int id_nexteffet;
        public int waitbeforenexteffet;
        public int chance_nexteffet;
        public int id_stat_resist_nexteffet;
        public int chance_resist_nexteffet;
        public int min_hit;
        public int max_hit;
        public int durer_min;
        public int durer_max;
        public int drain;
        public int typedee;
        public int nbdee;
        public int basevaleur;
        public int chance_crit;
        public int bonus_crit;
        public Boolean positif;
        public int id_stat;
        public int id_zoneeffect;
        public int id_type;
        public Boolean is_magique;
        public Dictionary<int,int> ratio;

        public Effet(int id)
        {
            bdd = new GestionBDD();
            this.id = id;
            DataTable tEffet = bdd.GetEffetbyId(id);
            DataRow[] drEffet = tEffet.Select();
            if (drEffet.Count() > 0) {
                nom = drEffet[0]["nom"].ToString();
                definition = drEffet[0]["definition"].ToString();
                id_nexteffet = Int32.Parse(drEffet[0]["id_nexteffet"].ToString());
                waitbeforenexteffet = Int32.Parse(drEffet[0]["waitbeforenexteffet"].ToString());
                chance_nexteffet = Int32.Parse(drEffet[0]["chance_nexteffet"].ToString());
                id_stat_resist_nexteffet = Int32.Parse(drEffet[0]["id_stat_resist_nexteffet"].ToString());
                chance_resist_nexteffet = Int32.Parse(drEffet[0]["chance_resist_nexteffet"].ToString());
                min_hit = Int32.Parse(drEffet[0]["min_hit"].ToString()) ;
                max_hit = Int32.Parse(drEffet[0]["max_hit"].ToString());
                durer_min = Int32.Parse(drEffet[0]["durer_min"].ToString());
                durer_max = Int32.Parse(drEffet[0]["durer_max"].ToString());
                drain = Int32.Parse(drEffet[0]["drain"].ToString());
                typedee = Int32.Parse(drEffet[0]["typedee"].ToString());
                nbdee = Int32.Parse(drEffet[0]["nbdee"].ToString());
                basevaleur = Int32.Parse(drEffet[0]["basevaleur"].ToString());
                chance_crit = Int32.Parse(drEffet[0]["chance_crit"].ToString());
                bonus_crit = Int32.Parse(drEffet[0]["bonus_crit"].ToString());
                positif = Boolean.Parse(drEffet[0]["positif"].ToString());
                id_stat = Int32.Parse(drEffet[0]["id_stat"].ToString());
                id_zoneeffect = Int32.Parse(drEffet[0]["id_zoneeffect"].ToString());
                id_type = Int32.Parse(drEffet[0]["id_type"].ToString());
                is_magique = Boolean.Parse(drEffet[0]["is_magique"].ToString());

                DataTable tStatEffet = bdd.GetStatEffetByID(id);
                DataRow[] drStatsEffet = tStatEffet.Select();
                ratio = new Dictionary<int, int>();

                foreach (DataRow row in drStatsEffet)
                {
                    int idstat = Int32.Parse(row["id_stat"].ToString());
                    int valeur = Int32.Parse(row["valeur"].ToString());
                    ratio.Add(idstat, valeur);
                }
            }
        }
    }
}
