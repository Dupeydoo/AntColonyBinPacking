using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AntColonyBinPacking.ACO.ACOCommon;
using AntColonyBinPacking.ACO.Interfaces;

namespace AntColonyBinPacking.ACO
{
    /// <summary>
    /// A partial class to ACOHelper to divide intialise and populate functionality.
    /// This class deals with the actual population of ants and edges.
    /// </summary>
    /// <author>640010970</author>
    /// <version>1.0.0</version>
    /// <see cref="ACOHelper"/>
    public static partial class ACOHelper
    {
        /// <summary>
        /// This method deals with the actual population of edges, given the number of bins and input items.
        /// </summary>
        /// <param name="edges">An empty list of edge lists to fill</param>
        /// <param name="inputCount">The number of input items</param>
        /// <param name="binNumber">The number of bins to place items into</param>
        /// <param name="random">A random object to generate random numbers for the first pheromone distribution</param>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Edge"/>
        private static void PopulateEdges(List<List<Edge>> edges, int inputCount, int binNumber, Random random)
        {
            // To generate unique edge id's allowing pheromone to be placed uniquely.
            int idCounter = 0;
            for (int item = 0; item < inputCount; item++)
            {
                // Create a new decision list
                List<Edge> decision = new List<Edge>();
                // For each bin
                for (int binCount = 1; binCount <= binNumber; binCount++)
                {
                    decision.Add
                    (
                        new Edge
                        {
                            EdgeId = binCount + idCounter,
                            // The intial pheromone distribution requires a random amount
                            PheromoneValue = AntMaths.GenerateRandomDouble(random),
                            EndNode_BinNumber = binCount
                        }
                    );
                }
                idCounter += binNumber;
                edges.Add(decision);
            }
        }

        /// <summary>
        /// This method deals with the actual population of 'ants' or ant paths.
        /// </summary>
        /// <param name="antPaths">The number of ant paths</param>
        /// <param name="random">A random object to help an ant probabilistically make a choice</param>
        /// <param name="ants">An empty Hashset of ants to populate</param>
        /// <param name="inputItems">A list of input items, each items value is its weight</param>
        /// <param name="graph">A construction graph for ants to traverse</param>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Ant"/>
        /// <see cref="ACO.Edge"/>
        /// <see cref="ACO.Interfaces.IConstructionGraph"/>
        /// <see cref="ACO.Interfaces.IConstructionGraph.ClearBinWeights"/>
        /// <see cref="ACO.Ant.MakeChoice(List{Edge}, Random, double, double[])"/>
        /// <see cref="ACO.Ant.CalculateAntFitness(double[])"/>
        private static void PopulateAnts(int antPaths, Random random,
            HashSet<Ant> ants, List<double> inputItems, IConstructionGraph graph)
        {
            // Get the graph edges
            List<List<Edge>> edges = graph.GraphDecisionEdges;
            for (int path = 1; path <= antPaths; path++)
            {
                // Make an ant
                Ant ant = new Ant { AntId = path };

                for (int edge = 0; edge < edges.Count; edge++)
                {
                    // For each edge list, get the corresponding item to add and have the ant make a choice
                    double item = inputItems[edge];
                    ant.MakeChoice(edges[edge], random, item, graph.BinWeights);
                }
                ant.CalculateAntFitness(graph.BinWeights);
                ants.Add(ant);
                // Clear the graph bin weights for next traversal
                graph.ClearBinWeights();
            }
        }
    }
}
