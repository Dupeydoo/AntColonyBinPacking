using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AntColonyBinPacking.ACO.Interfaces;

namespace AntColonyBinPacking.ACO
{
    class ConstructionGraph : IConstructionGraph
    {
        public ConstructionGraph()
        {
            this.BinWeights = new List<double>();
        }

        public int BinLevels { get; set; }
        // public int BinNodeCount { get; set; }
        public List<double> BinWeights { get; set; }
        public List<Edge> GraphEdges { get; set; }

        public double GetFitness(List<double> BinWeights)
        {
            return 4;
        }
    }
}
