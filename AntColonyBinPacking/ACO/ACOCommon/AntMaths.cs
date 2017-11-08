using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO.ACOCommon
{
    public static class AntMaths
    {
        public readonly static double PHEROMONE_UPDATE_CONSTANT = 100;
        public static double GenerateRandomDouble(Random random)
        {
            double rand = random.Next();
            return 1 - (rand / int.MaxValue);
        }

        public static double CalculatePheromoneLay(double constant, double antFitness)
        {
            return constant / antFitness;
        }

        public static double ReturnBestFitness(HashSet<Ant> ants)
        {
            double min = Double.MaxValue;
            foreach(Ant ant in ants)
            {
                double fitness = ant.AntFitness;
                if (fitness < min) min = fitness;
            }
            return min;
        }
    }
}
