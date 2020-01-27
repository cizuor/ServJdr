using JDR.BDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Model.Objet
{
    public abstract class Items
    {
        protected int id;
        protected String nom;
        protected String definition;
        public int type;
        protected int poid;
        protected int prix;
        public Qualite qualité;
        public Materiel materiel;
        public Genre genre;
        private GestionBDD bdd;

        abstract public int GetPrix();
        abstract public int GetPoid();
        abstract public int GetId();
        public static Items GetItems(int id, out int type)
        {
            GestionBDD bdd = new GestionBDD();

            DataTable tItems = bdd.GetItemById(id);
            DataRow[] drItems = tItems.Select();
            type = Int32.Parse(drItems[0]["type"].ToString());
            String nom = drItems[0]["nom"].ToString();
            String definition = drItems[0]["definition"].ToString();
            int prix = Int32.Parse(drItems[0]["prix"].ToString());
            int poid = Int32.Parse(drItems[0]["poid"].ToString());
            int idGenre = Int32.Parse(drItems[0]["id_genre"].ToString());
            int idMateriel = Int32.Parse(drItems[0]["id_materiel"].ToString());
            int idQualite = Int32.Parse(drItems[0]["id_qualite"].ToString());
            Genre genre = new Genre(idGenre);
            Materiel materiel = new Materiel(idMateriel);
            Qualite qualité = new Qualite(idQualite);
            switch (type)
            {
                case (int)Genre.TypeObjet.Utilitaire:
                    return new Utilitaire(id, type, nom, definition, prix, poid, genre, materiel, qualité);
                case (int)Genre.TypeObjet.Consommable:
                    Console.WriteLine("Case 1");
                    break;
                case (int)Genre.TypeObjet.Equipement:
                    return new Equipement(id, type, nom, definition, prix, poid, genre, materiel, qualité);
                case (int)Genre.TypeObjet.Composant:
                    return new Composant(id, type, nom, definition, prix, poid, genre, materiel, qualité);
                default:
                    Console.WriteLine("inconnue");
                    break;
            }
            return null;
        }


        public Items(int id, int type, String nom, String definition, int prix, int poid, Genre genre, Materiel materiel, Qualite qualité)
        {
            bdd = new GestionBDD();

            this.id = id;
            this.nom = nom;
            this.definition = definition;
            this.prix = prix;
            this.poid = poid;
            this.genre = genre;
            this.materiel = materiel;
            this.qualité = qualité;

        }



        public static int NewItem(String nom, String definition, int prix, int poid, int id_genre, int id_materiel, int id_qualité)
        {
            int idItem = -1;
            GestionBDD conn = new GestionBDD();
            // getStatRace 
            DataTable tObjet = conn.GetItems();
            DataRow[] rowItems = tObjet.Select();
            String idtmp = rowItems[rowItems.Count() - 1]["id"].ToString();
            Int32.TryParse(idtmp, out idItem);
            idItem++;
            DataRow item = tObjet.NewRow();
            item["id"] = idItem;
            item["nom"] = nom;
            item["definition"] = definition;
            item["poid"] = poid;
            item["prix"] = prix;
            item["id_genre"] = id_genre;
            item["id_materiel"] = id_materiel;
            item["id_qualite"] = id_qualité;
            tObjet.Rows.Add(item);
            conn.SubmitDataSetChanges("objet");

            return idItem;

        }

       
    }

}


    

    
