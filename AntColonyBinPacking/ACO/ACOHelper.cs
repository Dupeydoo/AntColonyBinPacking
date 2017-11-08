using AntColonyBinPacking.ACO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    /// <summary>
    /// A static class to house the initilisation functionality of the ACO.
    /// Input items, ants and edges call into the class for intiliasation.
    /// </summary>
    /// <author>640010970</author>
    /// <version>2.0.0</version>
    /// <see cref="ACORunner"/>
    public static partial class ACOHelper
    {
        /// <summary>
        /// A method to intialise the input items with the correct weights.
        /// </summary>
        /// <param name="inputs">A list to hold the inputs</param>
        /// <param name="binPackingProblem">The enum value of a bin packing problem</param>
        /// <version>1.0.0</version>
        /// <see cref="AntColonyBinPacking.ACO.Enumerations.BinProblemsEnum"/>
        internal static void InitialiseInputItems(List<double> inputs, int binPackingProblem)
        {
            // if the problem is BPP1
            if (binPackingProblem == 0)
            {
                for (int item = 1; item <= 500; item++)
                {
                    inputs.Add(item);
                }
            }
            // if the problem is BPP2
            else if (binPackingProblem == 1)
            {
                for (int item = 1; item <= 500; item++)
                {
                    // Calculate the second power of item i and divide by two
                    double outputItem = Math.Pow(item, 2) / 2;
                    inputs.Add(outputItem);
                }
            }

        }

        /// <summary>
        /// This method initialises 'ants' or ant paths to traverse the construction graph.
        /// </summary>
        /// <param name="antPaths">The number of ant paths to generate</param>
        /// <param name="graph">The construction graph the ants will traverse</param>
        /// <param name="binNumber">The number of bins to pack items into</param>
        /// <param name="inputItems">The items to be packed into bins</param>
        /// <returns>Hashset of Ants for quick add and iteration without concern for order</returns>
        /// <version>1.5.0</version>
        /// <see cref="ACOHelper.PopulateAnts(int, Random, HashSet{Ant}, List{double}, IConstructionGraph)"/>
        /// <see cref="ACO.Ant"/>
        internal static HashSet<Ant> InitialiseAnts(int antPaths, IConstructionGraph graph, int binNumber, List<double> inputItems)
        {
            // Hashsets are faster, but care not for order
            HashSet<Ant> ants = new HashSet<Ant>();
            // Random constructor takes the seed from the current time, so will be different for each trial
            Random random = new Random();
            PopulateAnts(antPaths, random, ants, inputItems, graph);
            return ants;
        }

        /// <summary>
        /// This method initialises the edges to be added to the construction graph depending on
        /// input items and number of bins.
        /// </summary>
        /// <param name="inputCount">Number of input items</param>
        /// <param name="binNumber">Number of bins to place items into</param>
        /// <returns>List of edges lists, where each list is a decision to an ant</returns>
        /// <version>2.0.0</version>
        /// <see cref="ACOHelper.PopulateEdges(List{List{Edge}}, int, int, Random)"/>
        /// <see cref="ACO.Edge"/>
        internal static List<List<Edge>> InitialiseEdges(int inputCount, int binNumber)
        {
            // Create an edge structure where each sublist represents a single ant decision
            List<List<Edge>> edges = new List<List<Edge>>();
            // Random constructor takes the seed from the current time, so will be different for each trial
            Random pheremoneGen = new Random();           
            PopulateEdges(edges, inputCount, binNumber, pheremoneGen);
            return edges;
        }
    }
}
