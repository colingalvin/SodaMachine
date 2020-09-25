using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            bool runAgain = false;
            do
            {
                Console.Clear();
                simulation.RunSimulation();
                runAgain = simulation.RunSimulationAgain();
            }
            while (runAgain);
        }
    }
}
