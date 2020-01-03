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
        public int GetTypeDée()
        {
            int total = genre.typeDée;// * (qualité.typeDée + materiel.typeDée);
            return total;
        }

        public int GetNbDée()
        {
            int total = genre.nbDée;//* (qualité.nbDée + materiel.nbDée);
            return total;
        }

        public int GetDamage()
        {
            int total = genre.damage + qualité.damage + materiel.damage;
            return total;
        }

        public int GetBaseDamage()
        {
            int total = genre.baseDamage + qualité.baseDamage + materiel.baseDamage;
            return total;
        }

        public int GetRatioF()
        {
            int total = genre.ratioF + qualité.ratioF + materiel.ratioF;
            return total;
        }

        public int GetRatioAg()
        {
            int total = genre.ratioAg + qualité.ratioAg + materiel.ratioAg;
            return total;
        }

        public int GetRatioInt()
        {
            int total = genre.ratioInt + qualité.ratioInt + materiel.ratioInt ;
            return total;
        }

        public int GetArmor()
        {
            float total = genre.armureBase + qualité.armureBase + materiel.armureBase;
            total = total + (
                ((total * genre.armureBonus)/100) +
                ((total * qualité.armureBonus)/100) +
                ((total * materiel.armureBonus)/100));
            return (int)total;
        }

        public int GetRM()
        {
            float total = genre.armureBase + qualité.armureBase + materiel.armureBase;
            total = total + (
                (total * genre.rmBonus) +
                (total * qualité.rmBonus) +
                (total * materiel.rmBonus));
            return (int)total;
        }

        public override int GetPoid()
        {
            float total = (genre.poid * ((qualité.poid + materiel.poid)-100))/100;
            return (int)total;
        }
        public int GetDegatCrit()
        {
            int total = (genre.degatcrit * ((qualité.degatcrit + materiel.degatcrit)-100))/100;
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

        public int GetNbMain()
        {
            return genre.nbMains;
        }


        public override int GetId()
        {
            return this.id;
        }
    }
}
