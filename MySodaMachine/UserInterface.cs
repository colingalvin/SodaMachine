using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    static class UserInterface
    {
        // member variables (HAS A)

        // constructor (SPAWN)

        // member methods (CAN DO)

        public static string MakeSelection(SodaMachine sodaMachine)
        {
            Console.Clear();
            sodaMachine.DisplayCurrentInventory();
            Console.Write("\nPlease make a selection: ");
            string userSelection = Console.ReadLine();
            return userSelection;
        }
    }
}
