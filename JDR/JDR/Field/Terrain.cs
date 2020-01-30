using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Field
{
    class Terrain
    {
        public SortedList<Perso, int> listPerso = new SortedList<Perso,int>();
        public List<Perso> next = new List<Perso>();
        public List<List<Case>> map;

        public Terrain(int largeur , int longueur)
        {
            this.map = new List<List<Case>>();
            int x;
            int y;
            for(x=0;x<largeur;x++)
            {
                this.map.Add(new List<Case>());
                for (y = 0; y < largeur; y++)
                {
                    this.map[x].Add(new Case());
                }
            }
        }

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
            map[x][y].perso = perso;
            map[x][y].occuper = true;
            perso.map = this;
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
            SortedList<Perso, int> listPersotmp = new SortedList<Perso, int>(listPerso);
            while (next.Count == 0)
            { 
                foreach (Perso p in listPersotmp.Keys)
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



        public Boolean DéplacementPerso(Perso perso,int x,int y)
        {
            int dist = Math.Abs(x - perso.positionX) + Math.Abs(y - perso.positionY);
            if (dist <= perso.MouvementRestant)
            {
                if (!map[x][y].occuper)
                {
                    map[perso.positionX][perso.positionY].occuper = false;
                    map[perso.positionX][perso.positionY].perso = null;
                    perso.MouvementRestant = perso.MouvementRestant - dist;
                    perso.positionX = x;
                    perso.positionY = y;
                    map[perso.positionX][perso.positionY].occuper = true;
                    map[perso.positionX][perso.positionY].perso = perso;
                    return true;
                }
            }
            return false;
        }


    }
}
