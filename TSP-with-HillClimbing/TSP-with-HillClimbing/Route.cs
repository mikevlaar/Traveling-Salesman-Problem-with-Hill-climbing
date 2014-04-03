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
            // Loop through all our destination cities and add them to our tour
            for (int cityIndex = 0; cityIndex < RouteManager.numberOfCities(); cityIndex++) 
            {
              insertCity(cityIndex, RouteManager.getCity(cityIndex));
            }
            // Randomly reorder the tour
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
            // If the tours been altered we need to reset the fitness and distance
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
                // Loop through our tour's cities
                for (int cityIndex=0; cityIndex < routeSize(); cityIndex++) 
                {
                    // Get city we're traveling from
                    City fromCity = getCity(cityIndex);
                    // City we're traveling to
                    City destinationCity;
                    // Check we're not on our tour's last city, if we are set our 
                    // tour's final destination city to our starting city
                    if(cityIndex+1 < routeSize())
                    {
                        destinationCity = getCity(cityIndex+1);
                    }
                    else
                    {
                        destinationCity = getCity(0);
                    }
                    // Get the distance between the two cities
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
