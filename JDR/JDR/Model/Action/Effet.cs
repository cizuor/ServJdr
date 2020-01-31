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
        public int id_nexteffet; // id de l'effet suplémentaire
        public int waitbeforenexteffet; // temps avant de lancer l'effect suplémentaire
        public int chance_nexteffet; // chance de lancer un effect suplémentaire
        public int id_stat_resist_nexteffet; // stat utilisé pour resisté a l 'effet 
        public int chance_resist_nexteffet; // % de la stat de resistance utilisé
        public int min_hit; // nombre min de foi ou l'effet se répéte
        public int max_hit; // nombre max de foi ou l'effet se répéte
        public int durer_min;  // duré de l'effet sur la cible min
        public int durer_max; // duré de l'effet sur la cible max 
        public int drain; // % de l'effet qui s'applique aussi a soi 
        public int typedee; // type de dée lancer par l'effet
        public int nbdee; // nombre de dée lancer par l'effet 
        public int basevaleur; // valeur de base 
        public int chance_crit; // chance de critique de l'effet
        public int bonus_crit; // bonus de dégats critique
        public Boolean positif; // si true alors la valuer est ajouter a la stat si false alors la valeur est retirer a la stat 
        public int id_stat; // stat atteinte par l'effet
        public int id_zoneeffect; // zonne d'effect
        public int id_type; // type de dégats;
        public Boolean is_magique; // si c'est magique ou physique  
        public Dictionary<int,int> ratio; // liste des id stat / % des stat prise en compte par l'attaquand pour amélioré son effect 
        public int id_stat_reduc; // stat prise en compte chez le déffenseur pour réduire l'effect
        public int coef_stat_reduc; // le % de la stat prise en compte chez le déffenseur pour réduire l'effect

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
                id_stat_reduc = Int32.Parse(drEffet[0]["id_stat_reduction"].ToString());
                coef_stat_reduc = Int32.Parse(drEffet[0]["coef_stat_reduction"].ToString());


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
