using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Quarter : Coin // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public Quarter()
        {
            name = "Quarter";
            value = 0.25;
        }

        // member methods (CAN DO)
    }
}
