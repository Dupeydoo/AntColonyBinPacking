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

        public void UpdatePheromones(HashSet<Ant> ants, double evaporationRate)
        {
            foreach(Ant ant in ants)
            {
                double pheromone = AntMaths.CalculatePheromoneLay(AntMaths.PHEROMONE_UPDATE_CONSTANT, ant.AntFitness);
                foreach (Edge edge in ant.EdgesVisited)
                {
                    // Edges are passed originally by reference, this allows the value in the 
                    // grid to be auto updated when the respective edge in an ant stack is modified
                    edge.PheromoneValue += pheromone;
                }
            }

            this.EvaporatePheromones(evaporationRate);
        }

        private void EvaporatePheromones(double evaporationRate)
        {
            foreach(List<Edge> edges in this.GraphDecisionEdges)
            {
                foreach(Edge edge in edges)
                {
                    edge.PheromoneValue *= evaporationRate;  // Is it only the evap rate or 1 - it? ask.
                }
            }
        }
    }
}
