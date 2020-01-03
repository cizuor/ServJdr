using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Outil
{
    public class DicoInt : Dictionary<int, int>
    {


        public int this[int key] {
            get
            {
                int retour = 0;
                if(!this.TryGetValue(key, out retour))
                {
                    retour = 0;
                }
                return retour;
            }
            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                }
                this.Add(key, value);
            }
        }

    }
}
