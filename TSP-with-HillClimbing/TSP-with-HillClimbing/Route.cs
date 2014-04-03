using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    public class Route
    {
        private List<City> route = new List<City>();
        private double distance = 0;

        /* Constructor that creates a blank route.
         */
        public Route()
        {
            for (int i = 0; i < RouteManager.numberOfCities(); i++) 
            {
                route.Add(null);
            }
        }

        /* Constructor overloading to create a route from another route using deepCopy.
         * @param route :The new route to create.
         */
        public Route(List<City> route)
        {
            this.route = GenericCopier<List<City>>.DeepCopy(route);
        }

        /* This method gets the route.
         * @return List<City> :The cities that the route contains.
         */
        public List<City> getRoute()
        {
            return route;
        }

        /* This method creates a random route.
         */
        public void generateRandomRoute() 
        {
            for (int cityIndex = 0; cityIndex < RouteManager.numberOfCities(); cityIndex++) 
            {
              insertCity(cityIndex, RouteManager.getCity(cityIndex));
            }
            randomizeRoute(route);
        }

        /* This method gets a city from the route at the given position.
         * @param routePosition :The position of the city in the route.
         * @return City :the city of the given position of the route.
         */
        public City getCity(int routePosition) 
        {
            return (City)route[routePosition];
        }

        /* This method inserts a city in a certain position within a route.
         * @param routePosition :The position to insert the city to the route.
         * @param city :The city to insert at the given position.
         */
        public void insertCity(int routePosition, City city) 
        {
            route[routePosition] = city;
            distance = 0;
        }

        /* This method gets the total distance of the route
         * @return double :The total distance.
         */
        public double getDistance()
        {
            if (distance == 0) 
            {
                double routeDistance = 0;

                for (int cityIndex=0; cityIndex < routeSize(); cityIndex++) 
                {
                    City fromCity = getCity(cityIndex);
                    City destinationCity;

                    if(cityIndex+1 < routeSize())
                    {
                        destinationCity = getCity(cityIndex+1);
                    }
                    else
                    {
                        destinationCity = getCity(0);
                    }
                    routeDistance += fromCity.distanceTo(destinationCity);
                }
                distance = routeDistance;
            }
            return distance;
        }

        /* This method gets the number of cities on the route.
         * @return int :The amount of cities on the route.
         */
        public int routeSize() 
        {
            return route.Count;
        }

        /* This method randomizes the given list of cities.
         * @param cityList :The city list to randomize.
         */
        private void randomizeRoute(List<City> cityList)
        {
            Random random = new Random();
            route = cityList.OrderBy(item => random.Next()).ToList<City>();
        }
    }
}
