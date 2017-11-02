using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO;

namespace AntColonyBinPacking.ACO.Interfaces
{
    public interface IConstructionGraph
    {
        // On initial setup the graphs bin weights are intitalised in chornology to the input bins.
        int BinLevels { get; set; }                     // Amount of different bins giving the levels of the graph.
        // int BinNodeCount { get; set; }                 // Amount of bin nodes present in the graph, given by (BinLevels * InputItemsCount) + 2 for S and E nodes.
        List<double> BinWeights { get; set; }          // When an ant reaches a BinNode, the BinNode reports to the graph and updates the total bin weight for a bin.
        List<List<Edge>> GraphEdges { get; set; }
        double GetFitness(List<double> BinWeights);    // A method to return the fitness of an ant run using difference between max and min bin weights.
    }
}
