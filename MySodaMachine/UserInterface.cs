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

        public static void MakeSelection(SodaMachine sodaMachine)
        {
            Console.Clear();
            DisplayChoices(sodaMachine);
            Console.Write("Please make a selection:");
            string userSelection = Console.ReadLine();
        }

        private static void DisplayChoices(SodaMachine sodaMachine)
        {
            int colaCansAvailable = 0;
            int orangeSodaCansAvailable = 0;
            int rootBeerCansAvailable = 0;
            foreach(Can can in sodaMachine.inventory)
            {
                switch(can.name)
                {
                    case "Cola":
                        colaCansAvailable++;
                        break;
                    case "Orange Soda":
                        orangeSodaCansAvailable++;
                        break;
                    case "Root Beer":
                        rootBeerCansAvailable++;
                        break;
                }
            }
            if(colaCansAvailable > 0)
            {
                Console.WriteLine("Type 1 for Cola");
            }
            else
            {
                Console.WriteLine("Cola (sold out)");
            }

            if (orangeSodaCansAvailable > 0)
            {
                Console.WriteLine("Type 2 for Orange Soda");
            }
            else
            {
                Console.WriteLine("Orange Soda (sold out)");
            }

            if (colaCansAvailable > 0)
            {
                Console.WriteLine("Type 3 for Root Beer");
            }
            else
            {
                Console.WriteLine("Root Beer (sold out)");
            }
        }
    }
}
