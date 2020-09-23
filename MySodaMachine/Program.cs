using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            Customer customer = new Customer();
            //customer.DisplayContents(customer.wallet);
            //customer.DisplayContents(customer.backpack);
            UserInterface.MakeSelection(sodaMachine);
        }
    }
}
