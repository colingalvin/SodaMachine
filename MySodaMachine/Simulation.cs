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
            string userSelection = UserInterface.MakeSelection(sodaMachine);
            sodaMachine.CompleteTransaction(userSelection, customer);
        }
    }
}
