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
        internal static HashSet<Ant> InitialiseAnts(int antPaths, List<Edge> edges, int binNumber)
        {
            HashSet<Ant> ants = new HashSet<Ant>();
            int startIndex = 0;
            for (int path = 1; path <= antPaths; path++)
            {
                List<Edge> choiceSet = new List<Edge>();
                Ant ant = new Ant { AntId = path };

                for(int edge=startIndex; edge < binNumber; edge++)
                {
                    choiceSet.Add(edges[edge]);
                }

                ant.MakeChoice(choiceSet);
                ants.Add(ant);
                startIndex += binNumber;
            }
            return ants;
        }

        internal static List<Edge> InitialiseEdges(int edgeFactor, int binNumber)
        {
            List<Edge> edges = new List<Edge>();
            Random pheremoneGen = new Random();           // Random constructor takes the seed from the current time, so will be different for each run
            int binCounter = 1;

            for(int ef = 1; ef <= edgeFactor; ef++)
            {
                edges.Add
                (
                    new Edge
                    {
                        EdgeId = ef,
                        PheromoneValue = GenerateRandomDouble(pheremoneGen),
                        EndNode_BinNumber = binCounter
                    }
                );

                if ((binCounter % binNumber) == 0) binCounter = 0;
                binCounter++;
            }
            return edges;
        }

        private static double GenerateRandomDouble(Random random)
        {
            double rand = random.Next();
            return 1 - (rand / int.MaxValue);
        }
    }
}
