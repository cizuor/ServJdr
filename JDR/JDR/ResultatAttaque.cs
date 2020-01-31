using JDR.Model.Action;
using JDR.Model.Objet;
using JDR.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class ResultatEffect
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
        public Effet effet;
        public ResultatEffect( String msg)
        {
            erreur = msg;
        }

        public ResultatEffect(Perso attaquant, Perso defenseur, Effet effet, int ChanceCrit , int dégatsCrit)
        {
            /*switch (arme.GetTypeEquipement())
            {
                case (int) Genre.typeEquipementBase.cac:
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CC].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCaC].GetValue() + 50;
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, out resultat, out reussite, int ChanceCrit, int dégatsCrit);
                    break;
                case (int)Genre.typeEquipementBase.dist:
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CT].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceDist].GetValue();
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
                    chanceToucher = GestionValeur.GetValeurOn100(chanceToucher);
                    chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
                    Roll.Attaque(chanceToucher, out resultat, out reussite, int ChanceCrit, int dégatsCrit);
                    break;
            }
            if (reussite)
            {
                CalculeEffet(attaquant, defenseur, arme);
                ReductionDegats(attaquant, defenseur, "physique");
            }*/
            CalculeEffet(attaquant, defenseur, ChanceCrit, dégatsCrit);
            // si il sagit de dégats
            if (effet.id_stat == (int)Stat.stats.PVManquand && effet.positif)
            {
                ReductionDegats(attaquant, defenseur);
            }
        }

        /// <summary>
        /// calcule la valeur de l'effet
        /// </summary>
        /// <param name="attaquant"></param>
        /// <param name="defenseur"></param>
        /// <param name="chanceCritBonus"></param>
        /// <param name="dégatsCritBonus"></param>
        public void CalculeEffet(Perso attaquant, Perso defenseur, int chanceCritBonus, int dégatsCritBonus)
        {
            this.degats = 0;
            // pour chaque effet de l'objet courant
           // foreach (Effet effet in arme.GetEffets())
            //{
            chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue() + (effet.chance_crit * chanceCritBonus) - defenseur.listStat[(int)Stat.stats.ResistanceCritique].GetValue();
            chanceCrit = GestionValeur.GetValeurOn100(chanceCrit);
            int nb = Roll.minmax(effet.min_hit, effet.max_hit);
            int i = 0;
            for ( i = 0 ; i < nb ; i++ )
            {
                //lance le test pour savoir si l'effet est critique 
                Roll.Attaque(chanceCrit, out resultatCrit, out reussiteCrit);
                int degatstmp = Roll.Degats(effet);
                int val = 0;
                // pour chaque stat qui a un ratio on calcule le gain et on le somme
                foreach (int stat in effet.ratio.Keys)
                {
                    val = val + (degatstmp * ((attaquant.listStat[stat].GetValue() * effet.ratio[stat]) / 100) / 100);
                }
                degatstmp = degatstmp + val;
                if (reussiteCrit)
                {
                    degatstmp = (degatstmp * dégatsCritBonus * effet.bonus_crit) / 100;
                    //degatstmp = (degatstmp * ((arme.GetDegatCrit() * effet.bonus_crit) +)) / 100;
                    //degatstmp = (degatstmp * arme.GetDegatCrit()) / 100;
                }
                    this.degats = this.degats + (int)(degatstmp);
             }
            //}
            /*if (critique)
            {
                int degatstmp = (this.degats * (attaquant.listStat[(int)Stat.stats.DegatCrit].GetValue()))/100;
                this.degats = this.degats + (int)degatstmp;
            }*/

          /*  // si il sagit de dégats
            if (effet.id_stat == (int)Stat.stats.PVManquand && effet.positif)
            {
                if (effet.is_magique)
                {
                    this.degats = (int)((this.degats * (attaquant.listStat[(int)Stat.stats.DegatInfligerMagique].GetValue() + 100)) / 100);
                }
                else
                {
                    this.degats = (int)((this.degats * (attaquant.listStat[(int)Stat.stats.DegatInfligerPhysique].GetValue() + 100)) / 100);
                }
                this.degats = (int)((this.degats * (attaquant.listStat[(int)Stat.stats.Degats].GetValue() + 100)) / 100);
            }*/
        }


        /// <summary>
        /// réduit les dégats subit par la cible 
        /// </summary>
        /// <param name="attaquant"></param>
        /// <param name="defenseur"></param>
        public void ReductionDegats(Perso attaquant, Perso defenseur)
        {
            int res = 0;
            if(effet.id_stat_reduc != -1)
            {
                res = defenseur.listStat[effet.id_stat_reduc].GetValue();
                if (effet.id_stat_reduc == (int)Stat.stats.resTotalphysique || effet.id_stat_reduc == (int)Stat.stats.Armure)
                {
                    foreach (Equipement equip in defenseur.listEquipement)
                    {
                        res += equip.GetArmor();
                    }
                }
                else if (effet.id_stat_reduc == (int)Stat.stats.resTotalMagique || effet.id_stat_reduc == (int)Stat.stats.RM)
                {
                    foreach (Equipement equip in defenseur.listEquipement)
                    {
                        res += equip.GetRM();
                    }
                }
                res = (res * (effet.coef_stat_reduc) / 100);
            }

            degatSubit = GestionValeur.ReductionDegats(this.degats, res);
        }

    }
}
