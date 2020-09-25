using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Customer
    {
        // member variables (HAS A)
        public Wallet wallet;
        public Backpack backpack;

        // constructor (SPAWN)
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        // member methods (CAN DO)
        //private void CountMoney()
        //{
        //    double totalMoney = 0;
        //    foreach (Coin coin in wallet.coins)
        //    {
        //        totalMoney += coin.Value;
        //    }
        //    string totalMoneyFormatted = totalMoney.ToString("C2");
        //    Console.WriteLine($"You currently have {totalMoneyFormatted} in your wallet.");
        //}

        public void DisplayContents(Wallet wallet)
        {
            double amountInWallet = Math.Round(Verification.CountMoney(wallet.coins),2);
            Console.WriteLine($"\nYou currently have ${amountInWallet} in your wallet.");
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int numberOfNickels = 0;
            int numberOfPennies = 0;
            if(wallet.coins.Count == 0)
            {
                Console.WriteLine("You currently have no coins in your wallet.");
            }
            else
            {
                foreach (Coin coin in wallet.coins)
                {
                    switch(coin.name)
                    {
                        case "Quarter":
                            numberOfQuarters++;
                            break;
                        case "Dime":
                            numberOfDimes++;
                            break;
                        case "Nickel":
                            numberOfNickels++;
                            break;
                        case "Penny":
                            numberOfPennies++;
                            break;
                    }
                }
                Console.WriteLine($"Your wallet contains {numberOfQuarters} quarters, {numberOfDimes} dimes, {numberOfNickels} nickels, and {numberOfPennies} pennies.");
            }
        }

        public void DisplayContents(Backpack backpack)
        {
            if(backpack.cans.Count == 0)
            {
                Console.WriteLine("You currently have nothing in your backpack.");
            }
            else
            {
                int cansOfCola = 0;
                int cansOfOrangeSoda = 0;
                int cansOfRootBeer = 0;
                foreach (Can can in backpack.cans)
                {
                    switch (can.name)
                    {
                        case "Cola":
                            cansOfCola++;
                            break;
                        case "Orange Soda":
                            cansOfOrangeSoda++;
                            break;
                        case "Root Beer":
                            cansOfRootBeer++;
                            break;
                    }
                }
                Console.WriteLine($"Your backpack contains {cansOfCola} can(s) of Cola, {cansOfOrangeSoda} can(s) of Orange Soda, and {cansOfRootBeer} can(s) of Root Beer.");
            }
        }

        public void InsertCoin(SodaMachine sodaMachine)
        {
            DisplayContents(wallet);
            Console.WriteLine("\nType 1 to insert quarter\nType 2 to insert dime\nType 3 to insert nickel\nType 4 to insert penny");
            string userInput = Console.ReadLine();
            string verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 4);
            Coin insertedCoin = null;
            while(insertedCoin == null)
            {
                switch(verifiedUserInput)
                {
                    case "1":
                        bool coinExists = Verification.CheckIfObjectExists(wallet.coins, "Quarter");
                        if (coinExists)
                        {
                            for (int i = 0; i < wallet.coins.Count; i++)
                            {
                                if (wallet.coins[i].name == "Quarter")
                                {
                                    insertedCoin = wallet.coins[i];
                                    wallet.coins.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You do not have any quarters to insert. Choose another coin.");
                            userInput = Console.ReadLine();
                            verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 4);
                            break;
                        }
                        break;
                    case "2":
                        coinExists = Verification.CheckIfObjectExists(wallet.coins, "Dime");
                        if(coinExists)
                        {
                            for (int i = 0; i < wallet.coins.Count; i++)
                            {
                                if (wallet.coins[i].name == "Dime")
                                {
                                    insertedCoin = wallet.coins[i];
                                    wallet.coins.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You do not have any dimes to insert. Choose another coin.");
                            userInput = Console.ReadLine();
                            verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 4);
                            break;
                        }
                        break;
                    case "3":
                        coinExists = Verification.CheckIfObjectExists(wallet.coins, "Nickel");
                        if (coinExists)
                        {
                            for (int i = 0; i < wallet.coins.Count; i++)
                            {
                                if (wallet.coins[i].name == "Nickel")
                                {
                                    insertedCoin = wallet.coins[i];
                                    wallet.coins.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You do not have any nickels to insert. Choose another coin.");
                            userInput = Console.ReadLine();
                            verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 4);
                            break;
                        }
                        break;
                    case "4":
                        coinExists = Verification.CheckIfObjectExists(wallet.coins, "Penny");
                        if (coinExists)
                        {
                            for (int i = 0; i < wallet.coins.Count; i++)
                            {
                                if (wallet.coins[i].name == "Penny")
                                {
                                    insertedCoin = wallet.coins[i];
                                    wallet.coins.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You do not have any pennies to insert. Choose another coin.");
                            userInput = Console.ReadLine();
                            verifiedUserInput = Verification.VerifyUserInput(userInput, 1, 4);
                            break;
                        }
                        break;
                }

            }
            sodaMachine.hopperIn.Add(insertedCoin);
        }
    }
}
