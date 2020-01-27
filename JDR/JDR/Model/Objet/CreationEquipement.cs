using JDR.BDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JDR.Model.Objet
{
    public class CreationEquipement
    {
        private int prixMoyen;
        private int variance;
        private int prixMax;
        private int prixMin;
        private Genre.typeEquipementBase typeEquip;
        private CreationEquipement.typeCible type;
        private int nbMain;
        private GestionBDD bdd;

        public CreationEquipement(int prixMoyen, int variance, Genre.typeEquipementBase typeEquip, int nbMain, CreationEquipement.typeCible typeCible)
        {
            this.prixMoyen = prixMoyen;
            this.variance = variance;
            this.typeEquip = typeEquip;
            this.nbMain = nbMain;
            this.type = typeCible;
            this.bdd = new GestionBDD();
            int varPrix = (prixMoyen * variance) / 100;
            this.prixMin = prixMoyen - varPrix;
            this.prixMax = prixMoyen + varPrix;
        }


        public int Generate()
        {
            int retour = 0;

            DataTable tGenre = bdd.GetGenre();
            DataRow[] drGenre;
            // ne marche que pour les arme 
            switch (type)
            {
                case CreationEquipement.typeCible.Guerrier:
                    drGenre = tGenre.Select("ratioint = 0 and typequip = "+ (int)typeEquip + " and nbmains = " + nbMain);
                    break;
                case CreationEquipement.typeCible.dist:
                    drGenre = tGenre.Select("portermin > 1  and typequip = "+ (int)typeEquip + " and nbmains = " + nbMain);
                    break;
                case CreationEquipement.typeCible.voleur:
                    drGenre = tGenre.Select("chanccrit > 5 and ratioint = 0  and typequip = "+ (int)typeEquip + " and nbmains = " + nbMain);
                    break;
                case CreationEquipement.typeCible.mage:
                    drGenre = tGenre.Select("ratioint > 0 and typequip = " + (int)typeEquip + " and nbmains = " + nbMain);
                    break;
                default:
                    drGenre = tGenre.Select("and typequip = " + (int)typeEquip + " and nbmains = " + nbMain);
                    break;
            }
            int posGenre = Roll.JetDée(drGenre.Count(), 1);
            int idGenre = Int32.Parse(drGenre[posGenre]["id"].ToString());
            int prixGenre = Int32.Parse(drGenre[posGenre]["prix"].ToString()); 

            DataTable tMateriel = bdd.GetMateriel();
            DataRow[] drMateriel = tMateriel.Select("type = 0 or type = 2 order by prix ");
            DataTable tQualite = bdd.GetQualite();
            DataRow[] drQualite = tQualite.Select("type = 0 or type = 2 order by prix ");
            int posMateriel = 0;
            int posQualite = 0;
            int prixMateriel = 0;
            int prixQualite = 0;
            int idMateriel = 0;
            int idQualite = 0;
            Boolean ok = false;
            int cpt = 0;
            while (!ok)
            {
                cpt = 0;
                posMateriel = Roll.JetDée(drMateriel.Count(), 1);
                prixMateriel = Int32.Parse(drMateriel[posMateriel]["prix"].ToString());
                if ((prixGenre * prixMateriel)/100 < prixMax)
                {
                    while (cpt < 10)
                    {
                        cpt++;
                        posQualite = Roll.JetDée(drQualite.Count(), 1);
                        prixQualite = Int32.Parse(drQualite[posQualite]["prix"].ToString());
                        if ((prixGenre * (prixMateriel + prixQualite - 100)) / 100 < prixMax && (prixGenre * (prixMateriel + prixQualite - 100)) / 100 > prixMin)
                        {
                            ok = true;
                            break;
                        }
                    }
                }
            }
            idMateriel = Int32.Parse(drMateriel[posMateriel]["id"].ToString());
            idQualite = Int32.Parse(drQualite[posQualite]["id"].ToString());
            // faire la même chose pour qualité et materiel et verifier le prix avant de les crée pour ne pas faire un appel pour chaque echec 
            String nom = drGenre[posGenre]["nom"].ToString() + " en " + drMateriel[posMateriel]["nom"].ToString() + " " + drQualite[posQualite]["nom"].ToString();
            retour = Items.NewItem(nom, "non", 0, 0, idGenre, idMateriel, idQualite);
            return retour;
        }


        public enum typeCible
        {
            Guerrier = 1,
            dist = 2,
            voleur = 3,
            mage = 4,
        }


    }
}
