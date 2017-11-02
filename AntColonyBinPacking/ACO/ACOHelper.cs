using AntColonyBinPacking.ACO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    public static class ACOHelper
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
            List<List<Edge>> edges = graph.GraphDecisionEdges;
            HashSet<Ant> ants = new HashSet<Ant>();
            Random random = new Random();
            PopulateAnts(antPaths, edges, random, ants, inputItems, graph.BinWeights);
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

        private static void PopulateEdges(List<List<Edge>> edges, int inputCount, int binNumber, Random random)
        {
            for(int item=0; item < inputCount; item++)
            {
                List<Edge> decision = new List<Edge>();
                for(int binCount=1; binCount <= binNumber; binCount++)
                {
                    decision.Add
                    (
                        new Edge
                        {
                            EdgeId = binCount,
                            PheromoneValue = GenerateRandomDouble(random),
                            EndNode_BinNumber = binCount
                        }
                    );
                }
                edges.Add(decision);
            }
        }

        private static void PopulateAnts(int antPaths, List<List<Edge>> edges, Random random, 
            HashSet<Ant> ants, List<double> inputItems, double[] binWeights)
        {
            int path = 1;
            while (path <= antPaths)
            {
                Ant ant = new Ant { AntId = path };

                for(int edge=0; edge < edges.Count; edge++)
                {
                    double item = inputItems[edge];
                    ant.MakeChoice(edges[edge], random, item, binWeights);
                }
                ants.Add(ant);
                path++;
            }
        }

        private static double GenerateRandomDouble(Random random)
        {
            double rand = random.Next();
            return 1 - (rand / int.MaxValue);
        }
    }
}
