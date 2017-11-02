using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    public class Ant
    {
        public Ant()
        {
            this.EdgesVisited = new Stack<Edge>();
        }

        public int AntId { get; set; }
        public int CurrentItem { get; set; }
        public Stack<Edge> EdgesVisited { get; set; }
        public double AntFitness { get; set; }

        public void MakeChoice(List<Edge> decisionSet, Random random)
        {
            double probabilitySum = decisionSet.Sum(x => x.PheromoneValue);
            double randDouble = random.NextDouble() * probabilitySum;
            double total = 0;

            foreach(Edge edge in decisionSet)
            {
                double edgeProbability = edge.PheromoneValue;
                total += edgeProbability;
                if(randDouble <= total)
                {
                    Edge chosenEdge = edge;
                    this.EdgesVisited.Push(chosenEdge);
                    break;
                }
            }      
        }

        public void CalculateAntFitness(List<double> binWeights)
        {
            this.AntFitness = binWeights.Max() - binWeights.Min();
        }
    }
}
