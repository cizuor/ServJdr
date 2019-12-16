using JDR.BDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    public class Items
    {
        protected int id;
        protected String nom;
        protected String definition;
        protected int type;
        protected int poid;
        protected int prix;
        private GestionBDD bdd;

        public int GetPrix()
        {
            return this.prix;
        }
        public int GetPoid()
        {
            return this.poid;
        }


        public static Items GetItems(int id, out int type)
        {
            GestionBDD bdd = new GestionBDD();

            DataTable tItems = bdd.GetItemById(id);
            DataRow[] drItems = tItems.Select();
            type = Int32.Parse(drItems[0]["type"].ToString());
            String nom = drItems[0]["nom"].ToString();
            String definition = drItems[0]["definition"].ToString();
            int prix = Int32.Parse(drItems[0]["id_genre"].ToString());
            int poid = Int32.Parse(drItems[0]["id_materiel"].ToString());
            switch (type)
            {
                case (int)TypeObjet.Utilitaire:
                    return new Items(id, type, nom, definition, prix, poid);
                case (int)TypeObjet.Consommable:
                    Console.WriteLine("Case 1");
                    break;
                case (int)TypeObjet.Arme:
                    int idGenre = Int32.Parse(drItems[0]["id_genre"].ToString());
                    int idMateriel = Int32.Parse(drItems[0]["id_materiel"].ToString());
                    int idQualite = Int32.Parse(drItems[0]["id_qualite"].ToString());
                    int nbMain = Int32.Parse(drItems[0]["nbmain"].ToString());
                    int idAttaque = Int32.Parse(drItems[0]["id_attaque"].ToString());
                    int idEffect = Int32.Parse(drItems[0]["id_effect"].ToString());
                    return new Equipement(id, type, nom, definition, prix, poid, idGenre, idMateriel, idQualite, nbMain, idAttaque);
                case (int)TypeObjet.Armure:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("inconnue");
                    break;
            }
            return null;
        }
        public Items(int id)
        {
            bdd = new GestionBDD();

            this.id = id;
            DataTable tItems = bdd.GetItemById(id);
            DataRow[] drItems = tItems.Select();
            this.type = Int32.Parse(drItems[0]["type"].ToString());
            this.nom = drItems[0]["nom"].ToString();
            this.definition = drItems[0]["definition"].ToString();
            this.prix = Int32.Parse(drItems[0]["id_genre"].ToString());
            this.poid = Int32.Parse(drItems[0]["id_materiel"].ToString());
        }


        public Items(int id, int type, String nom, String definition, int prix, int poid)
        {
            bdd = new GestionBDD();

            this.id = id;
            this.type = type;
            this.nom = nom;
            this.definition = definition;
            this.prix = prix;
            this.poid = poid;
        }

        public enum TypeObjet
        {
            Utilitaire = 0,
            Consommable = 1,
            Arme = 2,
            Armure = 3
        }
    }

}


    

    
