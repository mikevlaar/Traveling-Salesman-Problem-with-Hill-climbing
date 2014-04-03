using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    public class RouteManager
    {
        private static List<City> destinationCities = new List<City>();

        /* This method adds a city to the destinationCities list.
         * @param city :The city to add.
         */
        public static void addCity(City city)
        {
            destinationCities.Add(city);
        }

        /* This method gets a city at the given index from the destinationCities list.
         * @param index :The position of the city in the destinationCities list.
         * @return City :The city of the given position.
         */
        public static City getCity(int index)
        {
            return (City)destinationCities[index];
        }

        /* Get the number of destination cities
         * @return int :The amount of cities in the destinationCities list.
         */
        public static int numberOfCities()
        {
            return destinationCities.Count;
        }
    }
}
