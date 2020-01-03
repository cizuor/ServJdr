using JDR.Model.Objet;
using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class ResultatAttaque
    {
        public int degats;
        public int chanceToucher;
        public int chanceCrit;
        public int resultat;
        public int resultatCrit;
        public Boolean reussite;
        public Boolean reussiteCrit;
        public int degatSubit = 0;
        public String erreur;
        public ResultatAttaque( String msg)
        {
            erreur = msg;
        }

        public ResultatAttaque(Perso attaquant, Perso defenseur, Equipement arme)
        {
            switch (arme.GetTypeEquipement())
            {
                case (int) Genre.typeEquipementBase.cac:
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CC].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCaC].GetValue() + 50;
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
                case (int)Genre.typeEquipementBase.dist:
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CT].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceDist].GetValue();
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
            }
            if (reussite)
            {
                CalculeDégats(attaquant, defenseur, arme, reussiteCrit);
                ReductionDegats(attaquant, defenseur, "physique");
            }
        }


        public void CalculeDégats(Perso attaquant, Perso defenseur, Equipement arme, Boolean critique)
        {
            this.degats = 0;
            switch (arme.GetTypeEquipement())
            {
                case (int)Genre.typeEquipementBase.cac:
                    if (arme.GetTypeEquipement() == (int)Genre.typeEquipementBase.cac)
                    {
                        int degatstmp = Roll.Degats(arme);
                        int RF = (attaquant.listStat[(int)Stat.stats.F].GetValue() * arme.GetRatioF())/100;
                        int RAg = (attaquant.listStat[(int)Stat.stats.Ag].GetValue() * arme.GetRatioAg())/100;
                        int RInt = (attaquant.listStat[(int)Stat.stats.Int].GetValue() * arme.GetRatioInt())/100 ;
                        degatstmp = degatstmp + ((degatstmp * RF) / 100) +
                            ((degatstmp * RAg) / 100) +
                            ((degatstmp * RInt) / 100);
                        if (critique)
                        {
                            degatstmp = (degatstmp * arme.GetDegatCrit())/100;
                        }
                        this.degats = this.degats + (int)(degatstmp);
                    }
                    break;
                case (int)Genre.typeEquipementBase.dist:
                    if (arme.GetTypeEquipement() == (int)Genre.typeEquipementBase.dist)
                    {
                        float degatstmp = Roll.Degats(arme);
                        if (critique)
                        {
                            degatstmp = (degatstmp * arme.GetDegatCrit())/100;
                        }
                        
                        this.degats = this.degats + (int)degatstmp;
                    }
                    break;
            }
            if (critique)
            {
                int degatstmp = (this.degats * (attaquant.listStat[(int)Stat.stats.DegatCrit].GetValue()))/100;
                this.degats = this.degats + (int)degatstmp;
            }
            this.degats = (int)((this.degats * (attaquant.listStat[(int)Stat.stats.DegatInfligerPhysique].GetValue() + 100)) / 100);
            this.degats = (int)((this.degats * (attaquant.listStat[(int)Stat.stats.Degats].GetValue() + 100)) / 100);
        }

        public void ReductionDegats(Perso attaquant, Perso defenseur,String type)
        {
            int res = 0;
            if (type != "magique")
            {
                foreach (Equipement equip in defenseur.listEquipement)
                {
                    res += equip.GetArmor();
                }
                res += defenseur.listStat[(int)Stat.stats.E].GetValue() + defenseur.listStat[(int)Stat.stats.Armure].GetValue();
                this.degats = (int)((this.degats * (defenseur.listStat[(int)Stat.stats.DegatSubitPhysique].GetValue()+100)) / 100);
            }
            else
            {
                foreach (Equipement equip in defenseur.listEquipement)
                {
                    res += equip.GetRM();
                }
                res += defenseur.listStat[(int)Stat.stats.Fm].GetValue() + defenseur.listStat[(int)Stat.stats.RM].GetValue();
                this.degats += (int)((this.degats * (defenseur.listStat[(int)Stat.stats.DegatInfligerMagique].GetValue() + 100)) / 100);
            }
            

            degatSubit = GestionValeur.ReductionDegats(this.degats, res);
        }

    }
}
