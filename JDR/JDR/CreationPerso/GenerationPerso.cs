using JDR.BDD;
using JDR.Model.Objet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.CreationPerso
{
    class GenerationPerso
    {
        private GestionBDD bdd;
        private int id_Race;
        private int id_SousRace;
        private int lvlMoyen;
        private int valEquip;
        private int nbMonstre;
        private List<int> id_Monstre;
        private int varianceLvl = 20;

        public GenerationPerso(int id_Race, int lvl, int valEquip, int nbMonstre,int id_SousRace =-1)
        {
            this.id_SousRace = id_SousRace;
            this.id_Race = id_Race;
            this.lvlMoyen = lvl;
            this.valEquip = valEquip;
            this.nbMonstre = nbMonstre;
            id_Monstre = new List<int>();
            bdd = new GestionBDD();
        }


        public List<int> GenerateAll()
        {
            //preparation a la geston  du lvl de chaque monstre 
            List<int> listidSousRace = new List<int>();
            int varLvl = (lvlMoyen * varianceLvl) / 100;

            //Todo gerrer la classe

            if(id_SousRace == -1)
            {
                listidSousRace = GetSousRace();
            }
            int i;
            for (i = 0 ; i < nbMonstre ; i++)
            {
                int realLvl = lvlMoyen - varLvl + Roll.JetDée(varLvl * 2, 1);
                if(id_SousRace == -1)
                {
                    Generate(id_Race, listidSousRace[i], 1, realLvl, i);
                }
                else
                {
                    Generate(id_Race, id_SousRace, 1, realLvl, i);
                }
            }
            return id_Monstre;
        }


        private void Generate(int idRace,int idSousRace, int idClasse,int lvl,int num)
        {
            CreationPerso builderPerso = new CreationPerso();
            int idPerso = builderPerso.CreatNewPerso(idRace, idClasse, idSousRace, lvl, "mob", num.ToString(), "non");
            Perso perso = new Perso(idPerso);
            CreationEquipement creation = new CreationEquipement(valEquip, 20, Genre.typeEquipementBase.cac, 1, CreationEquipement.typeCible.Guerrier);
            int idequip = creation.Generate();
            int type;
            Items item = Items.GetItems(idequip,out type);
            perso.Equipe((Equipement) item);

        }

        private List<int> GetSousRace()
        {
            List<int> list_id_SousRace = new List<int>();
            DataTable tSousRace = bdd.GetSousRaceByRaceId(id_Race);
            DataRow[] rowSousRace = tSousRace.Select();

            int total = rowSousRace.Length;
            int i;
            for (i = 0 ; i < nbMonstre ; i++)
            {
                int val = Roll.JetDée(total, 1);
                list_id_SousRace.Add(Int32.Parse(rowSousRace[val]["id"].ToString()));
            }
            return list_id_SousRace;

        }



    }
}
