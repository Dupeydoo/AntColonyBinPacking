﻿using System;
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
            return random.NextDouble();   // Generates a random double
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
                if (fitness < min) min = fitness;
            }
            return min;
        }

        /// <summary>
        /// Finds the average fitness in a population of ants.
        /// </summary>
        /// <param name="ants">A population of ants</param>
        /// <returns>A double representing the average fitness</returns>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Ant"/>
        public static double ReturnAverageFitness(HashSet<Ant> ants)
        {
            double sum = 0;
            foreach(Ant ant in ants)
            {
                sum += ant.AntFitness;
            }
            return sum / ants.Count;
        }

        /// <summary>
        /// A method to find the variance of a populations fitnesses
        /// </summary>
        /// <param name="ants">The population of ants</param>
        /// <param name="mean">The average fitness of the population</param>
        /// <returns>A double representing the variance</returns>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Ant"/>
        public static double ReturnFitnessVariance(HashSet<Ant> ants, double mean)
        {
            double squaredDifferences = 0;
            foreach(Ant ant in ants)
            {
                squaredDifferences += Math.Pow((ant.AntFitness - mean), 2);
            }
            return squaredDifferences / ants.Count;
        }
    }
}
