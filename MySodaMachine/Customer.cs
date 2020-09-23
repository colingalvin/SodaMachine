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
        private void CountMoney()
        {
            double totalMoney = 0;
            foreach (Coin coin in wallet.coins)
            {
                totalMoney += coin.Value;
            }
            string totalMoneyFormatted = totalMoney.ToString("C2");
            Console.WriteLine($"You currently have {totalMoneyFormatted} in your wallet.");
        }

        public void DisplayContents(Wallet wallet)
        {
            CountMoney();
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
                foreach (Can can in backpack.cans)
                {
                    int cansOfCola = 0;
                    int cansOfOrangeSoda = 0;
                    int cansOfRootBeer = 0;
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
                    Console.WriteLine($"Your wallet contains {cansOfCola} cans of Cola, {cansOfOrangeSoda} cans of Orange Soda, and {cansOfRootBeer} cans of Root Beer.");
                }
            }
        }
    }
}
