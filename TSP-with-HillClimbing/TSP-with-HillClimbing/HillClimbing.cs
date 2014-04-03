using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    class HillClimbing
    {
        public void createCities()
        {
            City city = new City(60, 200);
            RouteManager.addCity(city);
            City city2 = new City(180, 200);
            RouteManager.addCity(city2);
            City city3 = new City(80, 180);
            RouteManager.addCity(city3);
            City city4 = new City(140, 180);
            RouteManager.addCity(city4);
            City city5 = new City(20, 160);
            RouteManager.addCity(city5);
            City city6 = new City(100, 160);
            RouteManager.addCity(city6);
            City city7 = new City(200, 160);
            RouteManager.addCity(city7);
            City city8 = new City(140, 140);
            RouteManager.addCity(city8);
            City city9 = new City(40, 120);
            RouteManager.addCity(city9);
            City city10 = new City(100, 120);
            RouteManager.addCity(city10);
            City city11 = new City(180, 100);
            RouteManager.addCity(city11);
            City city12 = new City(60, 80);
            RouteManager.addCity(city12);
            City city13 = new City(120, 80);
            RouteManager.addCity(city13);
            City city14 = new City(180, 60);
            RouteManager.addCity(city14);
            City city15 = new City(20, 40);
            RouteManager.addCity(city15);
            City city16 = new City(100, 40);
            RouteManager.addCity(city16);
            City city17 = new City(200, 40);
            RouteManager.addCity(city17);
            City city18 = new City(20, 20);
            RouteManager.addCity(city18);
            City city19 = new City(60, 20);
            RouteManager.addCity(city19);
            City city20 = new City(160, 20);
            RouteManager.addCity(city20);
        }

        public void search()
        {
            Route currentSolution = new Route();
            currentSolution.generateRandomRoute();
            Random random = new Random();

            Console.WriteLine("Route Distance: " + currentSolution.getDistance());

            Route best = new Route(currentSolution.getRoute());
            int notOptimal = 0;

            while (notOptimal < 120)
            {
                Route newSolution = new Route(currentSolution.getRoute());

                int tourPos1 = (int)(newSolution.routeSize() * random.NextDouble());
                int tourPos2 = (int)(newSolution.routeSize() * random.NextDouble());

                City citySwap1 = newSolution.getCity(tourPos1);
                City citySwap2 = newSolution.getCity(tourPos2);

                newSolution.insertCity(tourPos2, citySwap1);
                newSolution.insertCity(tourPos1, citySwap2);

                double currentDistance = currentSolution.getDistance();
                double neighbourDistance = newSolution.getDistance();

                if (currentDistance >= neighbourDistance)
                {
                    currentSolution = new Route(newSolution.getRoute());
                }

                if (currentSolution.getDistance() < best.getDistance())
                {
                    best = new Route(currentSolution.getRoute());
                    Console.WriteLine("Route Distance: " + best.getDistance());
                    notOptimal = 0;
                }
                else
                {
                    notOptimal++;
                }
            }
        }
    }
}
