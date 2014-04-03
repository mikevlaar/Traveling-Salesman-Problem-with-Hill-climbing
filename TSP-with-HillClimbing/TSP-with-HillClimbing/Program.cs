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
            // Create and add our cities
            City city = new City(60, 200);
            TourManager.addCity(city);
            City city2 = new City(180, 200);
            TourManager.addCity(city2);
            City city3 = new City(80, 180);
            TourManager.addCity(city3);
            City city4 = new City(140, 180);
            TourManager.addCity(city4);
            City city5 = new City(20, 160);
            TourManager.addCity(city5);
            City city6 = new City(100, 160);
            TourManager.addCity(city6);
            City city7 = new City(200, 160);
            TourManager.addCity(city7);
            City city8 = new City(140, 140);
            TourManager.addCity(city8);
            City city9 = new City(40, 120);
            TourManager.addCity(city9);
            City city10 = new City(100, 120);
            TourManager.addCity(city10);
            City city11 = new City(180, 100);
            TourManager.addCity(city11);
            City city12 = new City(60, 80);
            TourManager.addCity(city12);
            City city13 = new City(120, 80);
            TourManager.addCity(city13);
            City city14 = new City(180, 60);
            TourManager.addCity(city14);
            City city15 = new City(20, 40);
            TourManager.addCity(city15);
            City city16 = new City(100, 40);
            TourManager.addCity(city16);
            City city17 = new City(200, 40);
            TourManager.addCity(city17);
            City city18 = new City(20, 20);
            TourManager.addCity(city18);
            City city19 = new City(60, 20);
            TourManager.addCity(city19);
            City city20 = new City(160, 20);
            TourManager.addCity(city20);

            // Initialize intial solution
            Tour currentSolution = new Tour();
            currentSolution.generateIndividual();
            Random random = new Random();

            Console.WriteLine("Initial solution distance: " + currentSolution.getDistance());

            // Set as current best
            Tour best = new Tour(currentSolution.getTour());

            // Loop until system has cooled
            for (int i = 0; i < 10000; i++)
            {
                // Create new neighbour tour
                Tour newSolution = new Tour(currentSolution.getTour());

                // Get a random positions in the tour
                int tourPos1 = (int)(newSolution.tourSize() * random.NextDouble());
                int tourPos2 = (int)(newSolution.tourSize() * random.NextDouble());

                // Get the cities at selected positions in the tour
                City citySwap1 = newSolution.getCity(tourPos1);
                City citySwap2 = newSolution.getCity(tourPos2);

                // Swap them
                newSolution.setCity(tourPos2, citySwap1);
                newSolution.setCity(tourPos1, citySwap2);

                // Get distance of solutions
                double currentEnergy = currentSolution.getDistance();
                double neighbourEnergy = newSolution.getDistance();

                // Decide if we should accept the neighbour
                if (currentEnergy >= neighbourEnergy)
                {
                    currentSolution = new Tour(newSolution.getTour());
                }

                // Keep track of the best solution found
                if (currentSolution.getDistance() < best.getDistance())
                {
                    best = new Tour(currentSolution.getTour());
                    Console.WriteLine("Final solution distance: " + best.getDistance());
                }
            }

            //Console.WriteLine("Tour: " + best.toString());

            Console.ReadLine();
        }
    }
}
