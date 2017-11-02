using AntColonyBinPacking.ACO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    public static partial class ACOHelper
    {
        internal static void InitialiseInputItems(List<double> inputs, int binPackingProblem)
        {
            if (binPackingProblem == 0)
            {
                for (int item = 1; item <= 500; item++)
                {
                    inputs.Add(item);
                }
            }

            else if (binPackingProblem == 1)
            {
                for (int item = 1; item <= 500; item++)
                {
                    double outputItem = Math.Pow(item, 2) / 2;
                    inputs.Add(outputItem);
                }
            }

        }

        // Generate random ant paths ergo intialise after edges and graph are done and modify the ants stacks with a random selection
        // of the edges
        internal static HashSet<Ant> InitialiseAnts(int antPaths, IConstructionGraph graph, int binNumber, List<double> inputItems)
        {
            
            HashSet<Ant> ants = new HashSet<Ant>();
            Random random = new Random();
            PopulateAnts(antPaths, random, ants, inputItems, graph);
            return ants;
        }

        internal static List<List<Edge>> InitialiseEdges(int inputCount, int binNumber)
        {
            List<List<Edge>> edges = new List<List<Edge>>();
            // Random constructor takes the seed from the current time, so will be different for each run
            Random pheremoneGen = new Random();           
            PopulateEdges(edges, inputCount, binNumber, pheremoneGen);
            return edges;
        }
    }
}
