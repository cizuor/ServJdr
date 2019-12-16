using JDR.Model.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    public static class Roll
    {
        private static Random rand = new Random();
        

        public static int JetDée(int taille , int nb)
        {
            int retour = 0;
            int i = 0;
            for (i = 0 ; i < nb; i++){
                retour += rand.Next(taille + 1);
            }
            return retour;
        } 


        public static void Attaque(float objectif , float objectifCrit , out int resultat , out int resultatCrit , out Boolean réussite , out Boolean critique)
        {
            resultat = JetDée(100, 1);
            resultatCrit = JetDée(100, 1);
            if(objectif > resultat)
            {
                réussite = true;
                if (objectifCrit > resultatCrit)
                {
                    critique = true;
                }
                else
                {
                    critique = false;
                }
            }
            else
            {
                réussite = false;
                critique = false;
            }
        }

        public static int Degats(Equipement arme)
        {
            int degats = 0;
            int resultat = JetDée(arme.GetTypeDée(), arme.GetNbDée());
            resultat = resultat + arme.GetBaseDamage();
            resultat = (int)((resultat * (arme.GetDamage()+100))/100);
            degats = resultat;
            return degats;
        }






        public static void Jet100(float objectif, out int resultat, out Boolean réussite)
        {
            resultat = JetDée(100, 1);
            if (objectif > resultat)
            {
                réussite = true;
            }
            else
            {
                réussite = false;
            }

        }

    }
}
