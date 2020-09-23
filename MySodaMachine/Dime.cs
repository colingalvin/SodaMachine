using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Dime : Coin // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public Dime()
        {
            name = "Dime";
            value = 0.10;
        }

        // member methods (CAN DO)
    }
}
