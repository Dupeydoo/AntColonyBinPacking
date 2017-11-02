using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO.Enumerations;
using AntColonyBinPacking.ACO.Interfaces;
using AntColonyBinPacking.ACO;

namespace AntColonyBinPacking
{
    class ACORunner
    {
        public static readonly int BIN_AMOUNT = 10;
        public static readonly double EVAPORATION_RATE = 0.9;
        public static readonly int ANT_PATHS = 10;
        public static readonly byte FITNESS_EVALUATIONS = 100;

        // First test 10 ant paths so 10 ants, 0.9 eval, 500 random items weight at i into 10 bins
        public static void Main(string[] args)
        {
            List<double> inputItems = new List<double>();
            ACOHelper.InitialiseInputItems(inputItems, (int)BinProblemsEnum.BPP1);
            List<List<Edge>> edges = ACOHelper.InitialiseEdges(inputItems.Count, BIN_AMOUNT);
            byte loopCounter = 1;

            IConstructionGraph binGraph = new ConstructionGraph
            {
                BinLevels = BIN_AMOUNT,
                GraphDecisionEdges = edges,
                BinWeights = new double[BIN_AMOUNT]
            };

            while(loopCounter <= FITNESS_EVALUATIONS)
            {
                HashSet<Ant> ants = ACOHelper.InitialiseAnts(ANT_PATHS, binGraph, BIN_AMOUNT, inputItems);
                binGraph.UpdatePheromones(ants);
                loopCounter++;
            }
            
            Console.ReadLine();  //Ensures the terminal window remains open.
        }
    }
}
