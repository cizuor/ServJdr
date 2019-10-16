using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Outil
{
    class DicoFloat : Dictionary<int, float>
    {


        public float this[int key] {
            get
            {
                float retour = 0;
                if(!this.TryGetValue(key, out retour))
                {
                    retour = 0;
                }
                return retour;
            }
                set => this[key] = value;

        }

    }
}
