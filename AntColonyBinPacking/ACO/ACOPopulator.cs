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
            for (int item = 0; item < inputCount; item++)
            {
                List<Edge> decision = new List<Edge>();
                for (int binCount = 1; binCount <= binNumber; binCount++)
                {
                    decision.Add
                    (
                        new Edge
                        {
                            EdgeId = binCount,
                            PheromoneValue = AntMaths.GenerateRandomDouble(random),
                            EndNode_BinNumber = binCount
                        }
                    );
                }
                edges.Add(decision);
            }
        }

        private static void PopulateAnts(int antPaths, List<List<Edge>> edges, Random random,
            HashSet<Ant> ants, List<double> inputItems, IConstructionGraph graph)
        {
            int path = 1;
            while (path <= antPaths)
            {
                Ant ant = new Ant { AntId = path };

                for (int edge = 0; edge < edges.Count; edge++)
                {
                    double item = inputItems[edge];
                    ant.MakeChoice(edges[edge], random, item, graph.BinWeights);
                }
                ants.Add(ant);
                graph.ClearWeights();
                path++;
            }
        }
    }
}
