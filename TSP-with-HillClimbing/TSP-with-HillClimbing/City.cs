using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    [Serializable]
    public class City {
        private int x;
        private int y;

        /* Constructor that creates a city at the chosen x, y location.
         * @param x :The x location of the city.
         * @param y :The y location of the city.
         */
        public City(int x, int y){
            this.x = x;
            this.y = y;
        }
    
        /* This method Gets the distance to the given city.
         * @param city :The city to compare with.
         */
        public double distanceTo(City city){
            int xDistance = Math.Abs(x - city.x);
            int yDistance = Math.Abs(y - city.y);
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
        
            return distance;
        }
    }
}
