using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class Terrain
    {
        public SortedList<Perso, int> listPerso = new SortedList<Perso,int>();
        public List<Perso> next = new List<Perso>();


        public Boolean AddPerso(Perso perso , int x , int y , int equipe,Boolean init)
        {
            foreach(Perso p in listPerso.Keys)
            {
                if(p.positionX == x && p.positionY == y)
                {
                    return false;
                }
            }
            perso.positionX = x;
            perso.positionY = y;
            perso.numEquipe = equipe;
            if (init)
            {
                listPerso.Add(perso, 1000);
            }
            else
            {
                listPerso.Add(perso, 0);
            }
            return true;
        }

        public Perso NextToPlay()
        {
            while (next.Count == 0)
            { 
                foreach (Perso p in listPerso.Keys)
                {
                    listPerso[p] +=  p.listStat[(int)Stat.stats.Initiative].GetValue() + Roll.JetDée(20,1);
                    if (listPerso[p]>1000)
                    {
                        listPerso[p] -= 1000;
                        next.Add(p);
                    }
                }
            }
            Perso perso = next[0];
            next.Remove(perso);
            return perso;
        }




    }
}
