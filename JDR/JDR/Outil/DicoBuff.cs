using JDR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Outil
{
    class DicoBuff : Dictionary<int, Buff>
    {


        public Buff this[int key]
        {
            get
            {
                Buff buff;
                if (!this.TryGetValue(key, out buff))
                {
                    return new Buff();
                }
                return buff;
            }
            set => this[key] = value;
        }

    }
}
