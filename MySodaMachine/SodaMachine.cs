using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
