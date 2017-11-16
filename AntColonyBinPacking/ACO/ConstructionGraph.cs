using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AntColonyBinPacking.ACO.Interfaces;
using AntColonyBinPacking.ACO.ACOCommon;

namespace AntColonyBinPacking.ACO
{
    /// <summary>
    /// A class representing the graph that contains edges that ants traverse.
    /// The graph holds reference of the weights of bins and knows how to apply pheromone update
    /// to each edge in the graph.
    /// </summary>
    /// <author>640010970</author>
    /// <version>2.0.0</version>
    /// <see cref="ACO.Edge"/>
    /// <see cref="ACO.Ant"/>
    /// <see cref="ACO.ACOCommon.AntMaths"/>
    /// <implements>ACO.IConstructionGraph</implements>
    class ConstructionGraph : IConstructionGraph
    {
        public int BinLevels { get; set; }                          // The number of levels of the graph, equal to the number of bins
        public double[] BinWeights { get; set; }                    // The global record of bin weights after a traversal
        public List<List<Edge>> GraphDecisionEdges { get; set; }    // The list of edge lists denoting the graphs structure

        /// <summary>
        /// This method clears the weights of the bins of a construction graph
        /// </summary>
        /// <version>1.0.0</version>
        /// <see cref="ACO.ConstructionGraph.BinWeights"/>
        public void ClearBinWeights()
        {
            Array.Clear(this.BinWeights, 0, BinWeights.Length);
        }

        /// <summary>
        /// This method performs update of each pheromone value according to ant fitness.
        /// </summary>
        /// <param name="ants">The ants who have traversed the graph</param>
        /// <param name="evaporationRate">The evaporation coefficient for pheromone evaporation</param>
        /// <version>2.0.0</version>
        /// <see cref="ACO.ConstructionGraph.EvaporatePheromones(double)"/>
        /// <see cref="ACO.ACOCommon.AntMaths.CalculatePheromoneLay(double, double)"/>
        /// <see cref="ACO.ACOCommon.AntMaths.PHEROMONE_UPDATE_CONSTANT"/>
        /// <see cref="ACO.Ant"/>
        public void UpdatePheromones(HashSet<Ant> ants, double evaporationRate)
        {
            foreach(Ant ant in ants)
            {
                // Calculate how much pheromone to lay on an edge
                double pheromone = AntMaths.CalculatePheromoneLay(AntMaths.PHEROMONE_UPDATE_CONSTANT, ant.AntFitness);
                // We only affect the edges visited by ants, as the pheromone to lay for non-visited edges is zero
                foreach (Edge edge in ant.EdgesVisited)
                {
                    // Edges are passed originally by reference, this allows the value in the 
                    // grid to be auto updated when the respective edge in an ant stack is modified
                    edge.PheromoneValue += pheromone;
                }
            }
            // Perform pheromone evaporation
            this.EvaporatePheromones(evaporationRate);
        }

        /// <summary>
        /// This method evaporates pheromone on each edge of the graph.
        /// </summary>
        /// <param name="evaporationRate"></param>
        /// <version>1.0.0</version>
        /// <see cref="ACO.Edge"/>
        private void EvaporatePheromones(double evaporationRate)
        {
            foreach(List<Edge> edges in this.GraphDecisionEdges)
            {
                foreach(Edge edge in edges)
                {
                    // Multiply pheromone by the evaporation coeffcient as denoted in the specification.
                    edge.PheromoneValue *= evaporationRate;  
                }
            }
        }
    }
}
