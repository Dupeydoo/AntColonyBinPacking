using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    /// <summary>
    /// A class to represent a singular ant.
    /// </summary>
    /// <author>640010970</author>
    /// <version>1.3.0</version>
    /// <see cref="ACO.Edge"/>
    public class Ant
    {
        /// <summary>
        /// A constructor to automatically initialise an ants edge stack.
        /// </summary>
        public Ant()
        {
            this.EdgesVisited = new Stack<Edge>();
        }

        public int AntId { get; set; }                   // Each ant can be uniquely identified
        public Stack<Edge> EdgesVisited { get; set; }    // Each ant maintains a stack of the edges it has visited in a traversal
        public double AntFitness { get; set; }           // The fitness of a singular ant's path, i.e. Max bin weight - Min bin weight

        /// <summary>
        /// A method which sets up a probabilistic choice for an ant before calling into its overloaded method.
        /// </summary>
        /// <param name="decisionSet">The bins the ant can choose to place an item into</param>
        /// <param name="random">A random object to help the ant make a probabilistic choice</param>
        /// <param name="weight">The weight of the current item to put in a bin</param>
        /// <param name="binWeights">The weights of each bin to maintain in the graph object</param>
        /// <version>1.1.0</version>
        /// <see cref="ACO.Edge"/>
        /// <see cref="ACO.Ant.MakeChoice(List{Edge}, double, double[], double, double)"/>
        public void MakeChoice(List<Edge> decisionSet, Random random, double weight, double[] binWeights)
        {
            // Compute the sum of all pheromone values of the edges in the decision list
            double probabilitySum = decisionSet.Sum(x => x.PheromoneValue);
            // Use that value to choose a random number between zero and the sum
            double randDouble = random.NextDouble() * probabilitySum;
            this.MakeChoice(decisionSet, weight, binWeights, probabilitySum, randDouble);
        }

        /// <summary>
        /// This overloaded method makes an ant choice between one of the bins.
        /// </summary>
        /// <param name="decisionSet">The possible bins an item can be placed into</param>
        /// <param name="weight">The weight of the current item</param>
        /// <param name="binWeights">The graph's recording of each bins weight</param>
        /// <param name="probabilitySum">The sum of the pheromone values in the decisionSet</param>
        /// <param name="randDouble">A random number between zero and the sum of the pheromones</param>
        /// <version>1.2.0</version>
        /// <see cref="ACO.Edge"/>
        public void MakeChoice(List<Edge> decisionSet, double weight, double[] binWeights, double probabilitySum,
            double randDouble)
        {
            double total = 0;
            for (int edge = 0; edge < decisionSet.Count; edge++)
            {
                // We check each edge to see if the ant chooses to traverse it
                Edge checkEdge = decisionSet[edge];
                double edgeProbability = checkEdge.PheromoneValue;
                total += edgeProbability;
                // Test to see if the incremental pheromone edge total is greater than the random number, larger pheromone values
                // add more to the total, and so are more likely to be chosen
                if (randDouble <= total)
                {
                    Edge chosenEdge = checkEdge;
                    // Update the bin weight that was chosen
                    binWeights[edge] += weight;
                    this.EdgesVisited.Push(chosenEdge);
                    break;
                }
            }
        }

        /// <summary>
        /// A method to calculate the fitness of an ant, maximum bin weight minus minimum bin weight
        /// </summary>
        /// <param name="binWeights">The graphs record of bin weights</param>
        public void CalculateAntFitness(double[] binWeights)
        {
            this.AntFitness = binWeights.Max() - binWeights.Min();
        }
    }
}
