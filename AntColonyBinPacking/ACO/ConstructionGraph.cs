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
        public int BinLevels { get; set; }
        public double[] BinWeights { get; set; }
        public List<List<Edge>> GraphDecisionEdges { get; set; }

        public double GetFitness(List<double> BinWeights)
        {
            return 4;
        }

        public void ClearWeights()
        {
            Array.Clear(this.BinWeights, 0, BinWeights.Length);
        }
    }
}
