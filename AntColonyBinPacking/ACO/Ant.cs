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

        public void MakeChoice(List<Edge> decisionSet, Random random, double weight, double[] binWeights)
        {
            double probabilitySum = decisionSet.Sum(x => x.PheromoneValue);
            double randDouble = random.NextDouble() * probabilitySum;
            this.MakeChoice(decisionSet, weight, binWeights, probabilitySum, randDouble);
        }

        public void MakeChoice(List<Edge> decisionSet, double weight, double[] binWeights, double probabilitySum,
            double randDouble)
        {
            double total = 0;
            for (int edge = 0; edge < decisionSet.Count; edge++)
            {
                Edge checkEdge = decisionSet[edge];
                double edgeProbability = checkEdge.PheromoneValue;
                total += edgeProbability;
                if (randDouble <= total)
                {
                    Edge chosenEdge = checkEdge;
                    binWeights[edge] += weight;
                    this.EdgesVisited.Push(chosenEdge);
                    break;
                }
            }
        }

        public void CalculateAntFitness(double[] binWeights)
        {
            this.AntFitness = binWeights.Max() - binWeights.Min();
        }
    }
}
