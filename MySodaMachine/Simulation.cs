using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Simulation
    {
        // member variables (HAS A)
        public SodaMachine sodaMachine;
        public Customer customer;

        // constructor (SPAWN)
        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }

        // member methods (CAN DO)

        public void RunSimulation()
        {
            UserInterface.DisplayWelcome();
            string userSelection = "0";
            while(userSelection == "0")
            {
                customer.InsertCoin(sodaMachine);
                double moneyInHopper = Math.Round(Verification.CountMoney(sodaMachine.hopperIn), 2);
                Console.WriteLine($"Money inserted: ${moneyInHopper}");
                userSelection = UserInterface.MakeSelection(sodaMachine); // User enters 0 to enter more money
            } // break out once selection has been made

            bool canCompleteTransaction = sodaMachine.ProcessTransaction(userSelection);
            if(canCompleteTransaction)
            {
                sodaMachine.CompleteTransaction(customer, userSelection);
            }
            else
            {
                sodaMachine.CancelTransaction(customer);
            }
        }

        public bool RunSimulationAgain()
        {
            bool runAgain;
            Console.Write("Would you like to purchase another soda?\nType 1 for yes, 2 for no: ");
            string userInput = Console.ReadLine();
            string verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 2);
            if(verifiedUserInput == "1")
            {
                runAgain = true;
                return runAgain;
            }
            else
            {
                runAgain = false;
                return runAgain;
            }
        }
    }
}
