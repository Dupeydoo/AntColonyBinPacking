using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO;

namespace AntColonyBinPacking.ACO.Interfaces
{
    /// <summary>
    /// An interface to provide the contract for a concrete ConstructionGraph object.
    /// By calling into this interface when instantiating the calling class is non-dependent
    /// on the concrete graph (dependency injection)
    /// </summary>
    /// <author>640010970</author>
    /// <version>1.0.0</version>
    /// <see cref="ACO.ConstructionGraph"/>
    /// <see cref="ACO.Edge"/>
    /// <see cref="ACO.Ant"/>
    public interface IConstructionGraph
    {
        int BinLevels { get; set; }                                          // The number of levels of the graph, equal to the number of bins
        double[] BinWeights { get; set; }                                    // The global record of bin weights after a traversal
        List<List<Edge>> GraphDecisionEdges { get; set; }                    // The list of edge lists denoting the graphs structure
        void ClearBinWeights();                                              // Clears the bin weights
        void UpdatePheromones(HashSet<Ant> ants, double evaporationRate);    // Performs pheromone update
    }
}
