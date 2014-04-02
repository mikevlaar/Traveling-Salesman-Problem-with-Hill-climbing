using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_with_HillClimbing
{
    /**This class approximates optimal tours using
     * a hill climbing algorithm with random restart.
     * @author Jam Jenkins
     */
    public class TravelingSalesPerson
    {
       /** fills a symmetric distance matrix with random values
         * between 0 and 1
         * @param size how big the matrix should be
         * @param seed where to start the random number generator
         * @return the symmetric distance matrix
         */
        public double[][] fillDistanceMatrix(int size, int seed)
        {
            double[][] distances=new double[size][];
            Random random=new Random(seed);
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    distances[i][j] = random.NextDouble();
                    distances[j][i] = distances[i][j];
                }
            }
            return distances;
        }

            /** swaps two cities in the tour and returns the
             * change in cost of the tour
             * @param tour the current tour
             * @param tourIndexA the position of the city to swap
             * @param tourIndexB the other position to swap
             * @param distances the symmetric distance matrix
             * @return the change in cost, negative indicating a
             * shorter new tour, and positive indicating an increase
             * in tour length
             */
            public double swap(int[] tour, int tourIndexA, int tourIndexB, double[][] distances)
            {
                return 0;
            }

            /** performs a hill climbing algorithm on the TSP with random restart.
             * @param tour where the best solution will be stored.
             * Initially the contents of this array are unspecified,
             * but it does include enough storage to keep the resulting
             * approximated optimal tour.
             * @param distances the symmetric distance matrix
             * @param restarts the number of times to start at a
             * new random solution
             * @param seed the seed for the random restart
             * @return the cost of the approximated optimal tour
             */
            public double getBestTour(int[] tour, double[][] distances, int restarts, int seed)
            {
                //must use random to create new randomly ordered tours
                Random random = new Random(seed);

                for (int i = 0; i < restarts; i++)
                {
                    randomizeTour(tour, random);
                    //put code here
                }

                return 0;
            }

            public void randomizeTour(int[] tour, Random random)
            {
                for (int i = 0; i < tour.Length; i++)
                {
                    tour[i] = i;
                    //randomize the tour from here
                }
            }
    }
}
