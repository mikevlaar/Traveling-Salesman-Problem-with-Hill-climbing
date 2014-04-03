using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    class Program
    {
        static void Main(string[] args)
        {
            HillClimbing hillClimbing = new HillClimbing();
            hillClimbing.createCities();
            hillClimbing.search();

            Console.ReadLine();
        }
    }
}
