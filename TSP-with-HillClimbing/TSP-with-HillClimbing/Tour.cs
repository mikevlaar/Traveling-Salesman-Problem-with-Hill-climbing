using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    public class Tour
    {
        // Holds our tour of cities
        private List<City> tour = new List<City>();
        // Cache
        private double distance = 0;
    
        // Constructs a blank tour
        public Tour()
        {
            for (int i = 0; i < TourManager.numberOfCities(); i++) 
            {
                tour.Add(null);
            }
        }
    
        // Constructs a tour from another tour
        public Tour(List<City> tour)
        {
            this.tour = GenericCopier<List<City>>.DeepCopy(tour);
        }
    
        // Returns tour information
        public List<City> getTour()
        {
            return tour;
        }

        // Creates a random individual
        public void generateIndividual() 
        {
            // Loop through all our destination cities and add them to our tour
            for (int cityIndex = 0; cityIndex < TourManager.numberOfCities(); cityIndex++) 
            {
              setCity(cityIndex, TourManager.getCity(cityIndex));
            }
            // Randomly reorder the tour
            randomizeTour(tour);
        }

        // Gets a city from the tour
        public City getCity(int tourPosition) 
        {
            return (City)tour[tourPosition];
        }

        // Sets a city in a certain position within a tour
        public void setCity(int tourPosition, City city) 
        {
            tour[tourPosition] = city;
            // If the tours been altered we need to reset the fitness and distance
            distance = 0;
        }
    
        // Gets the total distance of the tour
        public double getDistance()
        {
            if (distance == 0) 
            {
                double tourDistance = 0;
                // Loop through our tour's cities
                for (int cityIndex=0; cityIndex < tourSize(); cityIndex++) 
                {
                    // Get city we're traveling from
                    City fromCity = getCity(cityIndex);
                    // City we're traveling to
                    City destinationCity;
                    // Check we're not on our tour's last city, if we are set our 
                    // tour's final destination city to our starting city
                    if(cityIndex+1 < tourSize())
                    {
                        destinationCity = getCity(cityIndex+1);
                    }
                    else
                    {
                        destinationCity = getCity(0);
                    }
                    // Get the distance between the two cities
                    tourDistance += fromCity.distanceTo(destinationCity);
                }
                distance = tourDistance;
            }
            return distance;
        }

        // Get number of cities on our tour
        public int tourSize() 
        {
            return tour.Count;
        }
    
        public String toString() 
        {
            String geneString = "|";
            for (int i = 0; i < tourSize(); i++) 
            {
                geneString += getCity(i)+"|";
            }
            return geneString;
        }

        private void randomizeTour(List<City> cityList)
        {
            Random random = new Random();
            tour = cityList.OrderBy(item => random.Next()).ToList<City>();
        }
    }
}
