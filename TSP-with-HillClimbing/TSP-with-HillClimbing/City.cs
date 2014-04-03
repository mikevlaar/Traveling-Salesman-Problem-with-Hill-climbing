using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    [Serializable]
    public class City {
        int x;
        int y;
    
        // Constructs a randomly placed city
        public City(){
            Random random = new Random();
            this.x = (int)(random.NextDouble()*200);
            this.y = (int)(random.NextDouble()*200);
        }
    
        // Constructs a city at chosen x, y location
        public City(int x, int y){
            this.x = x;
            this.y = y;
        }
    
        // Gets city's x coordinate
        public int getX(){
            return this.x;
        }
    
        // Gets city's y coordinate
        public int getY(){
            return this.y;
        }
    
        // Gets the distance to given city
        public double distanceTo(City city){
            int xDistance = Math.Abs(getX() - city.getX());
            int yDistance = Math.Abs(getY() - city.getY());
            double distance = Math.Sqrt( (xDistance*xDistance) + (yDistance*yDistance) );
        
            return distance;
        }

        public String toString(){
            return getX()+", "+getY();
        }
    }
}
