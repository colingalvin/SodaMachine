using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class SodaMachine
    {
        // member variables (HAS A)
        public List<Coin> register;
        public List<Can> inventory;

        // constructor (SPAWN)
        public SodaMachine()
        {
            register = new List<Coin>();
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickel = new Nickel();
            Penny penny = new Penny();
            UpdateInventory(quarter, 20);
            UpdateInventory(dime, 10);
            UpdateInventory(nickel, 20);
            UpdateInventory(penny, 50);
            
            inventory = new List<Can>();
            Cola cola = new Cola();
            OrangeSoda orangeSoda = new OrangeSoda();
            RootBeer rootBeer = new RootBeer();
            UpdateInventory(cola, 20);
            UpdateInventory(orangeSoda, 20);
            UpdateInventory(rootBeer, 20);
        }

        // member methods (CAN DO)
        private void UpdateInventory(Coin coin, int numberOfCoins)
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                register.Add(coin);
            }
        }

        private void UpdateInventory(Can can, int numberOfCans)
        {
            for (int i = 0; i < numberOfCans; i++)
            {
                inventory.Add(can);
            }
        }

        public void DisplayCurrentInventory()
        {
            int colaCansAvailable = 0;
            int orangeSodaCansAvailable = 0;
            int rootBeerCansAvailable = 0;
            foreach (Can can in inventory)
            {
                switch (can.name)
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
            if (colaCansAvailable > 0)
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

        public void CompleteTransaction(string userInput, Customer customer)
        {
            // Select soda based on userSelection
            string[] userSelection = SelectSoda(userInput);
            string sodaName = userSelection[0];
            double sodaCost = double.Parse(userSelection[1]);
            // WHILE LOOP - while customer has not yet entered enough change
            while(sodaCost > 0)
            {
                Console.Clear();
                // Display selection & remaining cost
                Console.WriteLine($"{sodaName}: {sodaCost} (amount remaining)");
                // Display customer wallet contents (current total and coin count)
                customer.DisplayContents(customer.wallet);
                // Customer inputs coin to deposit
                double coinValue = customer.InsertCoin();
                // Coin removed from customer wallet and stored in soda machine hopper

                // Subtract coin value from cost of selection
                sodaCost -= coinValue;
            }
            // When enough money has been entered
                // Compare cost to amount entered
            if(sodaCost == 0) // If no change due
            {
                // Deposit coins from hopper into machine
                // Remove can from machine inventory, add can to customer backpack

            }
            else if(sodaCost < 0)
            {
                // If change is due, run check change method

            }
                
                    // If correct change can be given
                        // Deposit coins from hopper into machine
                        // Remove can from machine inventory, add can to customer backpack
                        // Remove correct coins from machine register, add to customer wallet
                    // If correct change cannot be given
                        // Display correct change cannot be given
                        // Return money from hopper to customer wallet
        }

        public string[] SelectSoda(string userInput)
        {
            string[] userSelection = new string[2];
            switch(userInput)
            {
                case "1":
                    userSelection[0] = "Cola";
                    userSelection[1] = "0.35";
                    break;
                case "2":
                    userSelection[0] = "Orange Soda";
                    userSelection[1] = "0.06";
                    break;
                case "3":
                    userSelection[0] = "Root Beer";
                    userSelection[1] = "0.60";
                    break;
            }
            return userSelection;
        }
    }
}
