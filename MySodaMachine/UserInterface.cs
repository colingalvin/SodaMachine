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
            string userInput = Console.ReadLine();
            string verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 3);
            bool canExists = false;
            while(!canExists)
            {
                switch(verifiedUserInput)
                {
                    case "1":
                        canExists = Verification.CheckIfObjectExists(sodaMachine.inventory, "Cola");
                        break;
                    case "2":
                        canExists = Verification.CheckIfObjectExists(sodaMachine.inventory, "Orange Soda");
                        break;
                    case "3":
                        canExists = Verification.CheckIfObjectExists(sodaMachine.inventory, "Root Beer");
                        break;
                }
                if(!canExists)
                {
                    Console.WriteLine("This soda is sold out. Please make another selection.");
                    userInput = Console.ReadLine();
                    verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 3);
                }
            }
            return verifiedUserInput;
        }

        //public static void 
    }
}
