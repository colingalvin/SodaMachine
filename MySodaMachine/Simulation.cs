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
            string paymentMethod = UserInterface.ChoosePaymentMethod();
            string userSelection = "0";
            if(paymentMethod == "1")
            {
                Console.Clear();
                Console.WriteLine($"Available funds: ${customer.wallet.card.AvailableFunds}");
                userSelection = UserInterface.MakeSelection(sodaMachine); // User enters 0 to enter more money
                bool canCompleteTransaction = sodaMachine.ProcessTransaction(userSelection, customer);
                if (canCompleteTransaction)
                {
                    double sodaCost = Math.Round(SodaMachine.GetSodaCost(userSelection), 2);
                    sodaMachine.CompleteTransaction(customer, sodaCost, userSelection);
                }
                else
                {
                    sodaMachine.CancelTransaction();
                }
            }
            else
            {
                while(userSelection == "0")
                {
                    customer.InsertPayment(sodaMachine);
                    double moneyInHopper = Math.Round(Verification.CountMoney(sodaMachine.hopperIn), 2);
                    Console.Clear();
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

        }

        public void DisplayAllStats()
        {
            Console.WriteLine("Press enter to display all current simulation statistics: ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Soda machine:" +
                $"\n{sodaMachine.inventory.Count} cans in inventory" +
                $"\n{sodaMachine.register.Count} coins in register totalling {Math.Round(Verification.CountMoney(sodaMachine.register), 2)}" +
                $"\n{sodaMachine.CardPaymentBalance} in card credits.\n");
            Console.WriteLine("Customer wallet:");
            customer.DisplayContents(customer.wallet);
            customer.DisplayContents(customer.backpack);
        }

        public bool RunSimulationAgain()
        {
            bool runAgain;
            Console.Write("\nWould you like to purchase another soda?\nType 1 for yes, Type 2 to end simulation: ");
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
