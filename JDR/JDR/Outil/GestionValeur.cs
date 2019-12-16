using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Outil
{
    public static class GestionValeur
    {
        public static int GetValeur(float valeur)
        {
            return (int)valeur;
        }

        public static int GetValeurOn100(float valeur)
        {
            return (int)(100 - (100 / (Math.Pow(2, (valeur / 50)))));
        }

    }
}
