using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO.ACOCommon
{
    /// <summary>
    /// A static class to provide generic mathematics pertaining to ants.
    /// </summary>
    /// <author>640010970</author>
    /// <version>1.0.0</version>
    /// <see cref="ACO.Ant"/>
    public static class AntMaths
    {
        public readonly static double PHEROMONE_UPDATE_CONSTANT = 100;     // The constant used to calculate the amount of pheromone to lay on an edge

        /// <summary>
        /// A method to generate a random double precision number between zero and one.
        /// </summary>
        /// <param name="random">A random object to generate with</param>
        /// <returns>A random double between zero and one</returns>
        /// <version>1.0.0</version>
        public static double GenerateRandomDouble(Random random)
        {
            double rand = random.Next();        // Generates a random double
            return 1 - (rand / int.MaxValue);
        }

        /// <summary>
        /// A method to calculate the amount of pheromone to lay on a graph edge
        /// </summary>
        /// <param name="constant">A constant to figure out how much pheromone to lay</param>
        /// <param name="antFitness">The ants fitness</param>
        /// <returns></returns>
        public static double CalculatePheromoneLay(double constant, double antFitness)
        {
            return constant / antFitness;
        }

        /// <summary>
        /// A method which iterates over an ant hashset and returns the smallest fitness value,
        /// in other words, the smallest bin weight difference.
        /// </summary>
        /// <param name="ants">A collection of ants</param>
        /// <returns>A double representing the smallest fitness value</returns>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Ant"/>
        public static double ReturnBestFitness(HashSet<Ant> ants)
        {
            double min = Double.MaxValue;
            foreach(Ant ant in ants)
            {
                double fitness = ant.AntFitness;
                // If the fitness is the smallest we have encountered, then the minimum is now that fitness
                if (fitness < min) min = fitness;
            }
            return min;
        }
    }
}
