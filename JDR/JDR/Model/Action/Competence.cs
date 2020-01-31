using JDR.BDD;
using JDR.Model.Objet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Action
{
    class Competence
    {
        public int id;
        public String nom;
        public String definition;
        public Boolean passif;
        public Boolean enLigne;
        public int type;
        public int difficulte;
        public int cout;
        public int id_zonne;
        public int id_effet;
        public int porter_min;
        public int porter_max;
        public int id_stat_reussite;
        public int coef_stat_reussite;
        public int id_stat_esquive;
        public int coef_stat_esquive;

        private GestionBDD bdd;

        public Competence(int id)
        {
            this.id = id;


            bdd = new GestionBDD();

            DataTable tComp = bdd.GetCompById(id);
            DataRow[] drComp = tComp.Select();
            nom = drComp[0]["nom"].ToString();
            definition = drComp[0]["definition"].ToString();
            passif = Boolean.Parse(drComp[0]["passif"].ToString());
            enLigne = Boolean.Parse(drComp[0]["ligne_only"].ToString());
            type = Int32.Parse(drComp[0]["type"].ToString());
            difficulte = Int32.Parse(drComp[0]["difficulte"].ToString());
            cout = Int32.Parse(drComp[0]["cout"].ToString());
            id_zonne = Int32.Parse(drComp[0]["id_zoneeffect"].ToString());
            id_effet = Int32.Parse(drComp[0]["id_effet"].ToString());
            porter_min = Int32.Parse(drComp[0]["porter_min"].ToString());
            porter_max = Int32.Parse(drComp[0]["porter_max"].ToString());
            id_stat_reussite = Int32.Parse(drComp[0]["id_stat_reussite"].ToString());
            coef_stat_reussite = Int32.Parse(drComp[0]["coef_stat_reussite"].ToString());
            id_stat_esquive = Int32.Parse(drComp[0]["id_stat_esquive"].ToString());
            coef_stat_esquive = Int32.Parse(drComp[0]["coef_stat_esquive"].ToString());


        }


        public void ActionGetRange(Perso perso , out int rangeMin , out int rangeMax)
        {

            rangeMin = 100;
            rangeMax = 0;
            int tmp;
            switch (type)
            {
                case (int)Type.Attaque:
                    foreach(Equipement equip in perso.listEquipement)
                    {
                        if (equip.IsArme())
                        {
                            tmp = equip.GetMinRange();
                            if(rangeMin > tmp)
                            {
                                rangeMin = tmp;
                            }
                            tmp = equip.GetMaxRange();
                            if (rangeMax < tmp)
                            {
                                rangeMax = tmp;
                            }
                        }
                    }
                    break;
                case (int)Type.Charge:
                    tmp = perso.listStat[(int)Stat.stats.Mouvement].valeur;
                    rangeMin = 2;
                    rangeMax = tmp + 1;

                    break;
                case (int)Type.ChangementArme:
                    rangeMin = 0;
                    rangeMax = 0;
                    break;
                case (int)Type.Utilisation_Objet:
                    rangeMin = 0;
                    rangeMax = 0;
                    break;
                case (int)Type.Normeaux:
                    rangeMin = porter_min;
                    rangeMax = porter_max;
                    break;

                default:
                    rangeMin = -1;
                    rangeMax = -1;
                    break;
            }


        }





        public enum Type
        {
            Attaque = 1,
            Normeaux = 2,
            ChangementArme = 3,
            Utilisation_Objet = 4,
            Charge = 5
        }
    }
}
