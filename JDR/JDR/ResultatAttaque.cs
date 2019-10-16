using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    class ResultatAttaque
    {
        public Boolean touche;
        public Boolean critique;
        public int degats;
        public int chanceToucher;
        public int chanceCrit;
        public int resultat;
        public int resultatCrit;
        public Boolean reussite;
        public Boolean reussiteCrit;

        public ResultatAttaque(Perso attaquant , Perso defenseur , String type)
        {
            switch (type)
            {
                case "cac":
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CC].GetValue(attaquant) - defenseur.listStat[(int)Stat.stats.ResistanceCaC].GetValue(defenseur);
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue(attaquant);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
                case "dist":
                    chanceToucher = attaquant.listStat[(int)Stat.stats.CT].GetValue(attaquant) - defenseur.listStat[(int)Stat.stats.ResistanceDist].GetValue(defenseur);
                    chanceCrit = attaquant.listStat[(int)Stat.stats.ChanceCrit].GetValue(attaquant);
                    Roll.Attaque(chanceToucher, chanceCrit, out resultat, out resultatCrit, out reussite, out reussiteCrit);
                    break;
            }
        }

    }
}
