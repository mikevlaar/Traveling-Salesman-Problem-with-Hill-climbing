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
               int[] sizes={10, 20, 30, 40};
                int[] seeds={1, 2, 3, 4};
                int[] restarts={20, 20, 20, 20};
                TravelingSalesPerson sales=new TravelingSalesPerson();
                for(int i=0; i<sizes.Length; i++)
                {
                    double[][] distances=sales.fillDistanceMatrix(sizes[i], seeds[i]);
                    int[] tour=new int[sizes[i]];
                    double cost=sales.getBestTour(tour, distances, restarts[i], seeds[i]);
                    Console.WriteLine("The following tour costs "+cost);
                    for (int j = 0; j < tour.Length; j++)
                    {
                        Console.WriteLine(tour[j] + " ");
                    }
                    Console.WriteLine();
                }
        }
    }
}
