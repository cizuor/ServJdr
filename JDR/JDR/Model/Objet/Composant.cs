﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    class Composant : Items
    {
        public Composant(int id, int type, String nom, String definition, int prix, int poid, Genre genre, Materiel materiel, Qualite qualité) : base(id, type, nom, definition, prix, poid, genre, materiel, qualité)
        {
        }

        public override int GetPrix()
        {
            return this.prix;
        }

        public override int GetPoid()
        {
            return this.poid;
        }

        public override int GetId()
        {
            return this.id;
        }
    }
}
