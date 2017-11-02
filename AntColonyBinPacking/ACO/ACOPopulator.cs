using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AntColonyBinPacking.ACO.ACOCommon;
using AntColonyBinPacking.ACO.Interfaces;

namespace AntColonyBinPacking.ACO
{
    public static partial class ACOHelper
    {
        private static void PopulateEdges(List<List<Edge>> edges, int inputCount, int binNumber, Random random)
        {
            int idCounter = 0;
            for (int item = 0; item < inputCount; item++)
            {
                List<Edge> decision = new List<Edge>();
                for (int binCount = 1; binCount <= binNumber; binCount++)
                {
                    decision.Add
                    (
                        new Edge
                        {
                            EdgeId = binCount + idCounter,
                            PheromoneValue = AntMaths.GenerateRandomDouble(random),
                            EndNode_BinNumber = binCount
                        }
                    );
                }
                idCounter += binNumber;
                edges.Add(decision);
            }
        }

        private static void PopulateAnts(int antPaths, Random random,
            HashSet<Ant> ants, List<double> inputItems, IConstructionGraph graph)
        {
            List<List<Edge>> edges = graph.GraphDecisionEdges;
            for (int path = 1; path <= antPaths; path++)
            {
                Ant ant = new Ant { AntId = path };

                for (int edge = 0; edge < edges.Count; edge++)
                {
                    double item = inputItems[edge];
                    ant.MakeChoice(edges[edge], random, item, graph.BinWeights);
                }
                ant.CalculateAntFitness(graph.BinWeights);
                ants.Add(ant);

                graph.ClearBinWeights();
            }
        }
    }
}
