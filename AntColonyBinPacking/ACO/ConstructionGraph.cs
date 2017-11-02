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
            foreach(Ant ant in ants)
            {
                double pheromone = AntMaths.CalculatePheromoneLay(AntMaths.PHEROMONE_UPDATE_CONSTANT, ant.AntFitness);
                foreach (Edge edge in ant.EdgesVisited)
                {
                    edge.PheromoneValue += pheromone;
                    //int edgeIndex = edge.EdgeId - 1;
                    //this.GraphDecisionEdges[edgeIndex / BinLevels][edge.EndNode_BinNumber] = edge;
                }
            }
        }
    }
}
