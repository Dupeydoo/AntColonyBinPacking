using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    /// <summary>
    /// A class to represent a singular graph edge.
    /// </summary>
    /// <author>64001070</author>
    /// <version>1.0.0</version>
    public class Edge
    {
        public int EdgeId { get; set; }                 // Each edge has a unique id to help lay pheromone
        public double PheromoneValue { get; set; }      // Each edge has a pheromone value laid by ants
        public int EndNode_BinNumber { get; set; }      // Each edge is connected to one of the bins in the problem
    }
}
