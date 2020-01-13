using JDR.BDD;
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


        private void GenerateAll()
        {
            List<int> listidSousRace;
            if(id_SousRace == -1)
            {
                listidSousRace = GetSousRace();
            }
            int i;
            for (i = 0 ; i < nbMonstre ; i++)
            {
                int tmpSousRace = 0;
                if(id_SousRace == -1)
                {

                }
            }
        }


        private void Generate(int idRace,int idSousRace, int idClasse,int lvl,int num)
        {
            CreationPerso builderPerso = new CreationPerso();
            int idPerso = builderPerso.CreatNewPerso(idRace, idClasse, idSousRace, lvl, "mob", num.ToString(), "non");
            Perso perso = new Perso(idPerso);
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
