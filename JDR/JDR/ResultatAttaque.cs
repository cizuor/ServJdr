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

        public ResultatAttaque(Perso attaquant , Perso defenseur , String type)
        {
            switch (type)
            {
                case "cac":
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CC].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCaC].GetValue()+50;
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
                case "dist":
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CT].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceDist].GetValue();
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
            }
            if (reussite)
            {
                CalculeDégats(attaquant, defenseur, type, reussiteCrit);
            }
        }



        public void CalculeDégats(Perso attaquant, Perso defenseur, String type,Boolean critique)
        {
            this.degats = 0;
            foreach (Equipement arme in attaquant.listEquipement) {
                switch (type)
                {
                    case "cac":
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
                    case "dist":
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
            }
            if (critique)
            {
                int degatstmp = (this.degats * (attaquant.listStat[(int)Stat.stats.DegatCrit].GetValue()))/100;
                this.degats = this.degats + (int)degatstmp;
            }
        }

    }
}
