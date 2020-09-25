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

        public static void DisplayWelcome()
        {
            Console.WriteLine("Press enter to insert coins and make a selection.");
            Console.ReadLine();
            Console.Clear();
        }

        public static string MakeSelection(SodaMachine sodaMachine)
        {
            Console.WriteLine("Please make a selection: ");
            sodaMachine.DisplayCurrentInventory();
            Console.Write("Enter your selection choice, or enter 0 to insert more coins.");
            string userInput = Console.ReadLine();
            string verifiedUserInput = Verification.VerifyUserInput(userInput, 0, 3);
            if(verifiedUserInput == "0")
            {
                return verifiedUserInput;
            }
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
    }
}
