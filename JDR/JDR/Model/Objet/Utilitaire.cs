using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    public class Utilitaire : Items
    {

        public Utilitaire(int id, int type, String nom, String definition, int prix, int poid) : base(id, type, nom, definition, prix, poid)
        {
        }
    }
}
