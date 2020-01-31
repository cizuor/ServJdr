using JDR.Model.Action;
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
                retour += rand.Next(taille)+1;
            }
            return retour;
        } 


        public static void Attaque(float objectif , out int resultat, out Boolean réussite)
        {
            resultat = JetDée(100, 1);
            if(objectif > resultat)
            {
                réussite = true;
            }
            else
            {
                réussite = false;
            }
        }

        public static int minmax(int min, int max)
        {
            int taille = max - min;
            taille++;

            int retour = JetDée(taille,1);

            retour --;
            return retour;
        }



        public static int Degats(Effet effet)
        {
            int degats = 0;
            int resultat = JetDée(effet.typedee, effet.nbdee);
            resultat = resultat + effet.basevaleur;
            //resultat = (int)((resultat * (arme.GetDamage()+100))/100);
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
