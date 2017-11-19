using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO.Enumerations;
using AntColonyBinPacking.ACO.Interfaces;
using AntColonyBinPacking.ACO.ACOCommon;
using AntColonyBinPacking.ACO;
using System.Diagnostics;

namespace AntColonyBinPacking
{
    /// <summary>
    /// The main runner class for the Ant Colony Optimisation
    /// of the Bin Packing Problem. Items of different weights
    /// are input into the algorithm and ants help to distribute
    /// these items into a fixed number of bins so that the difference
    /// between lightest and heaviest bin is minimised.
    ///
    /// The number of bins, pheromone evaporation rate, number of ants,
    /// and number of fitness evaluations for a single trial are assigned here.
    /// Algorithm inputs are intialised and a construction graph to hold the
    /// pheromone is created.
    ///
    /// When the algorithm has terminated the best fitness, average, variance
    /// and S.D is reported to the user.
    /// </summary>
    /// 
    /// <author>640010970</author>
    /// <version>3.4.2</version>
    /// <see cref="ACO"/>
    class ACORunner
    {
        public static readonly int BIN_AMOUNT = 10;                       // The number of bins to place items into
        public static readonly double EVAPORATION_RATE = 0.6;             // The rate of evaporation for pheromone
        public static readonly int ANT_PATHS = 10;                        // The number of ant paths to generate
        public static readonly int FITNESS_EVALUATIONS_LIMIT = 10000;     // The number of single fitness evaluations to carry out in a trial
        public static readonly Random random = new Random();

        /// <summary>
        /// The main method for running the ACO.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <version>2.2.0</version>
        /// <see cref="ACO"/>
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<double> inputItems = new List<double>();
            ACOHelper.InitialiseInputItems(inputItems, (int)BinProblemsEnum.BPP1);   // Change BPP1 to BPP2 when wanting to use BPP2 items.
            // Create a structure of edges based on bin amount and input items. Each List<Edge> represents a single ant decision.
            List<List<Edge>> edges = ACOHelper.InitialiseEdges(inputItems.Count, BIN_AMOUNT, random);
            HashSet<Ant> ants = new HashSet<Ant>();
            int generation = 1;

            // Create the construction graph with dependency injection
            IConstructionGraph binGraph = new ConstructionGraph
            {
                BinLevels = BIN_AMOUNT,
                GraphDecisionEdges = edges,
                BinWeights = new double[BIN_AMOUNT]
            };

            // Main ACO while loop. Must carry out a fixed amount of fitness evaluations with varying Ant Paths
            while(generation <= (FITNESS_EVALUATIONS_LIMIT / ANT_PATHS))
            {
                ants = ACOHelper.InitialiseAnts(ANT_PATHS, binGraph, BIN_AMOUNT, inputItems, random);
                binGraph.UpdatePheromones(ants, EVAPORATION_RATE);
                generation++;
            }
            
            TrialOutput(stopwatch, ants);
        }

        /// <summary>
        /// Calculates and outputs the results of a trial
        /// </summary>
        /// <param name="stopwatch">The timer for a trial</param>
        /// <param name="bestFitness">The best fitness in the population</param>
        /// <param name="averageFitness">The average fitness of the population</param>
        /// <version>1.0.0</version>
        /// <see cref="ACO.ACOCommon.AntMaths"/> 
        private static void TrialOutput(Stopwatch stopwatch, HashSet<Ant> ants)
        {
            double bestFitness = AntMaths.ReturnBestFitness(ants);
            double averageFitness = AntMaths.ReturnAverageFitness(ants);
            double fitnessVariance = AntMaths.ReturnFitnessVariance(ants, averageFitness);

            stopwatch.Stop();
            Console.WriteLine("Best Fitness: {0}", bestFitness);
            Console.WriteLine("Average Fitness: {0}", averageFitness);
            Console.WriteLine("Fitness Variance: {0}", fitnessVariance);
            // Sqrt of variance gives standard deviation
            Console.WriteLine("Fitness Standard Deviation: {0}", Math.Sqrt(fitnessVariance));
            Console.WriteLine("Trial took: {0}", stopwatch.Elapsed.ToString());
            Console.ReadLine();  // Ensures the terminal window remains open.
        }
    }
}
