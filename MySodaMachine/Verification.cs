using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    static class Verification
    {
        public static bool CheckIfCoinsExist(List<Coin> register, string coinName)
        {
            bool coinExists = false;
            foreach (Coin coin in register)
            {
                if(coin.name == coinName)
                {
                    coinExists = true;
                    return coinExists;
                }
            }
            return coinExists;
        }
    }
}
