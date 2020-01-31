using JDR.Model.Action;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    public class Equipement : Items
    {
        public Equipement(int id, int type, String nom, String definition, int prix, int poid, Genre genre,Materiel materiel, Qualite qualite) : base(id, type, nom, definition, prix, poid, genre, materiel, qualite)
        {
            int total = genre.prix * (((qualité.prix + materiel.prix)/100)-1);
            base.prix= total;
            total = genre.poid * (((qualité.poid + materiel.poid)/100)-1);
            base.poid = total;
            SetMalusAg();
        }

        private void SetMalusAg()
        {
            int tmp = GetPoid();
            if (GetPoid() > 50)
            {
                genre.stat[(int)Stat.stats.Ag] = (GetPoid()-50) / 10;
            }
        }

        public override int GetPrix()
        {
            int total = (genre.prix * ((qualité.prix + materiel.prix)-100))/100;
            return total;
        }


        public int GetDamage()
        {
            int total = 0;
            if (genre.typeEquipement != (int)Genre.typeEquipementBase.armure)
            {
                total = genre.damage + qualité.damage + materiel.damage;
            }
            return total;
        }

        public int GetArmor()
        {
            float total = 0;
            if (genre.typeEquipement == (int)Genre.typeEquipementBase.armure || genre.typeEquipement == (int)Genre.typeEquipementBase.bouclier)
            {
                total = genre.armureBase + qualité.armureBase + materiel.armureBase;
                total = total + (
                    ((total * genre.armureBonus) / 100) +
                    ((total * qualité.armureBonus) / 100) +
                    ((total * materiel.armureBonus) / 100));
            }
            return (int)total;
        }

        public int GetRM()
        {
            float total = 0;
            if (genre.typeEquipement == (int)Genre.typeEquipementBase.armure || genre.typeEquipement == (int)Genre.typeEquipementBase.bouclier)
            {
                total = genre.armureBase + qualité.armureBase + materiel.armureBase;
                total = total + (
                    (total * genre.rmBonus) +
                    (total * qualité.rmBonus) +
                    (total * materiel.rmBonus));
            }
            return (int)total;
        }

        public override int GetPoid()
        {
            float total = (genre.poid * ((qualité.poid + materiel.poid)-100))/100;
            return (int)total;
        }
        public int GetDegatCrit()
        {
            int total = (genre.degatcrit * qualité.degatcrit * materiel.degatcrit)/ 1000000;
            return total;
        }
        public int GetChanceCrit()
        {
            int total = (genre.chancecrit * qualité.chancecrit * materiel.chancecrit) / 1000000;
            return total;
        }

        public int GetPsort()
        {
            int total = (genre.pSort * (( qualité.pSort + materiel.pSort)))/100;
            return total;
        }

        public int GetStat(int idStat)
        {
            float total = genre.stat[idStat] + qualité.stat[idStat] + materiel.stat[idStat];
            return (int)total;
        }

        public int GetTypeEquipement()
        {
            return genre.typeEquipement;
        }

        public Boolean IsInRange(int dist)
        {
            if(dist >= genre.pMin && dist <= genre.pMax)
            {
                return true;
            }
            return false;
        }

        public int GetMinRange()
        {
            return genre.pMin;
        }
        public int GetMaxRange()
        {
            return genre.pMax;
        }


        public int GetNbMain()
        {
            return genre.nbMains;
        }

        public List<Effet> GetEffets()
        {
            List<Effet> retour = new List<Effet>();
            retour.AddRange(genre.effets);
            retour.AddRange(qualité.effets);
            retour.AddRange(materiel.effets);
            return retour;
        }

        public Boolean IsArme()
        {
            if(genre.typeEquipement == (int)Genre.typeEquipementBase.cac || genre.typeEquipement == (int)Genre.typeEquipementBase.dist)
            {
                return true;
            }
            return false;
        }

        public override int GetId()
        {
            return this.id;
        }
    }
}
