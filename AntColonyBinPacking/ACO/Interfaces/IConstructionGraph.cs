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
        int BinLevels { get; set; }                     
        double[] BinWeights { get; set; }          
        List<List<Edge>> GraphDecisionEdges { get; set; }
        void ClearBinWeights();
        void UpdatePheromones(HashSet<Ant> ants);
    }
}
