using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AntColonyBinPacking.ACO.Interfaces;
using AntColonyBinPacking.ACO.ACOCommon;

namespace AntColonyBinPacking.ACO
{
    class ConstructionGraph : IConstructionGraph
    {
        public int BinLevels { get; set; }
        public double[] BinWeights { get; set; }
        public List<List<Edge>> GraphDecisionEdges { get; set; }

        public void ClearBinWeights()
        {
            Array.Clear(this.BinWeights, 0, BinWeights.Length);
        }

        public void UpdatePheromones(HashSet<Ant> ants)
        {

        }
    }
}
