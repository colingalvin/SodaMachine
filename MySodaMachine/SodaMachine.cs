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
        public List<Coin> hopperIn;
        public List<Coin> hopperOut;
        public List<Can> inventory;

        // constructor (SPAWN)
        public SodaMachine()
        {
            hopperIn = new List<Coin>();
            hopperOut = new List<Coin>();
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
            string[] userSelection = SelectSoda(userInput); // Collect name and cost info to display during transaction
            string sodaName = userSelection[0];
            double sodaCost = Math.Round(double.Parse(userSelection[1]), 2);
            // WHILE LOOP - while customer has not yet entered enough change
            while (Math.Round(sodaCost, 2) > 0)
            {
                Console.Clear();
                // Display selection & remaining cost
                Console.WriteLine($"{sodaName}: ${Math.Round(sodaCost, 2)} (amount remaining)");
                // Display customer wallet contents (current total and coin count)
                customer.DisplayContents(customer.wallet);
                // Customer inputs coin to deposit
                Coin insertedCoin = customer.InsertCoin();
                // Coin removed from customer wallet and stored in soda machine hopper
                hopperIn.Add(insertedCoin);
                // Subtract coin value from cost of selection
                sodaCost -= Math.Round(insertedCoin.Value, 2);
            }
            // When enough money has been entered
            // Compare cost to amount entered
            if (Math.Round(sodaCost, 2) == 0) // If no change due
            {
                // Deposit coins from hopper into machine
                foreach (Coin coin in hopperIn.ToList()) //  throw exception?
                {
                    Console.WriteLine("Transaction complete, no change due!");
                    register.Add(coin);
                    hopperIn.Remove(coin);
                }
                // Remove can from machine inventory, add can to customer backpack
                customer.backpack.cans.Add(DispenseSoda(sodaName));
            }
            else if(Math.Round(sodaCost, 2) < 0) // If change is due, run check change method
            {
                double changeDue = Math.Round(Math.Abs(sodaCost), 2); // Pass absolute value of sodaCost (how much change is due)
                bool canCompletePurchase = DispenseChange(changeDue); // Checks if exact change can be given
                if(canCompletePurchase == true)
                {
                    Console.WriteLine("Transaction complete, change due!");
                    foreach (Coin coin in hopperIn.ToList()) // Machine takes in hopperIn coins
                    {
                        register.Add(coin);
                        hopperIn.Remove(coin);
                    }
                    customer.backpack.cans.Add(DispenseSoda(sodaName)); // Remove can from machine inventory, add can to customer backpack
                    foreach (Coin coin in hopperOut.ToList()) // Dispense hopperOut change to customer
                    {
                        customer.wallet.coins.Add(coin);
                        hopperIn.Remove(coin);
                    }
                }
                else
                {
                    Console.WriteLine("Transaction cannot be completed - exact change unavailable.");
                    foreach (Coin coin in hopperIn.ToList()) // Return hopperIn coins to customer
                    {
                        customer.wallet.coins.Add(coin);
                        hopperIn.Remove(coin);
                    }
                }

            }
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

        public Can DispenseSoda(string sodaName)
        {
            Can dispensedSoda = null;
            switch (sodaName)
            {
                case "Cola":
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[1].name == "Cola")
                        {
                            dispensedSoda = inventory[i];
                            inventory.RemoveAt(i);
                            break;
                        }
                    }
                    break;
                case "Orange Soda":
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[1].name == "Orange Soda")
                        {
                            dispensedSoda = inventory[i];
                            inventory.RemoveAt(i);
                            break;
                        }
                    }
                    break;
                case "Root Beer":
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[1].name == "Root Beer")
                        {
                            dispensedSoda = inventory[i];
                            inventory.RemoveAt(i);
                            break;
                        }
                    }
                    break;
            }
            return dispensedSoda;
        }

        public bool DispenseChange(double changeDue)
        {
            // Calculate total change available, ensure than change available is greater than change due
            bool canGiveExactChange = false;
            while (Math.Round(changeDue, 2) >= 0.25)
            {
                bool coinExists = Verification.CheckIfCoinsExist(register, "Quarter");// Check if quarters exist
                if(coinExists)
                {
                    for (int i = 0; i < register.Count; i++)
                    {
                        if(register[i].name == "Quarter")// Iterate through and remove quarter
                        {
                            hopperOut.Add(register[i]); // Add removed coins to hopper
                            register.RemoveAt(i); // Remove coin from register
                            changeDue = Math.Round(changeDue - 0.25, 2); // Decrease change due
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            while (Math.Round(changeDue, 2) >= 0.10)
            {
                bool coinExists = Verification.CheckIfCoinsExist(register, "Dime");
                if(coinExists)
                {
                    for (int i = 0; i < register.Count; i++)
                    {
                        if (register[i].name == "Dime")// Iterate through and remove quarter
                        {
                            hopperOut.Add(register[i]); // Add removed coins to hopper
                            register.RemoveAt(i); // Remove coin from register
                            changeDue = Math.Round(changeDue - 0.10, 2); // Decrease change due
                            break;
                        }
                    }
                }
                break;
            }
            while (Math.Round(changeDue, 2) >= 0.05)
            {
                bool coinExists = Verification.CheckIfCoinsExist(register, "Nickel");
                if(coinExists)
                {
                    for (int i = 0; i < register.Count; i++)
                    {
                        if (register[i].name == "Nickel")// Iterate through and remove quarter
                        {
                            hopperOut.Add(register[i]); // Add removed coins to hopper
                            register.RemoveAt(i); // Remove coin from register
                            changeDue = Math.Round(changeDue - 0.05, 2); // Decrease change due
                            break;
                        }
                    }
                }
                break;
            }
            while (Math.Round(changeDue, 2) > 0)
            {
                bool coinExists = Verification.CheckIfCoinsExist(register, "Nickel");
                if(coinExists)
                {
                    for (int i = 0; i < register.Count; i++)
                    {
                        if (register[i].name == "Penny")// Iterate through and remove quarter
                        {
                            hopperOut.Add(register[i]); // Add removed coins to hopper
                            register.RemoveAt(i); // Remove coin from register
                            changeDue = Math.Round(changeDue - 0.01, 2); // Decrease change due
                            break;
                        }
                    }
                }
                break;
            }
            // Add removed coins to hopper, dispense only if reach even change
            if (Math.Round(changeDue, 2) == 0.00)
            {
                canGiveExactChange = true;
                // Transfer coins from hopper to customer
                return canGiveExactChange;
            }
            else
            {
                // Return coins to machine register
                return canGiveExactChange;
            }
        }
    }
}
