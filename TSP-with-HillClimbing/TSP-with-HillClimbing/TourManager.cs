using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    public class TourManager
    {
        // Holds our cities
        private static List<City> destinationCities = new List<City>();

        // Adds a destination city
        public static void addCity(City city)
        {
            destinationCities.Add(city);
        }

        // Get a city
        public static City getCity(int index)
        {
            return (City)destinationCities[index];
        }

        // Get the number of destination cities
        public static int numberOfCities()
        {
            return destinationCities.Count;
        }
    }
}
