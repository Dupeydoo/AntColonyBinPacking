using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    public static class ACOHelper
    {
        internal static void InitialiseInputItems(List<double> inputs, int binPackingProblem)
        {
            if (binPackingProblem == 0)
            {
                for (int item = 1; item <= 500; item++)
                {
                    inputs.Add(item);
                }
            }

            else if (binPackingProblem == 1)
            {
                for (int item = 1; item <= 500; item++)
                {
                    double outputItem = Math.Pow(item, 2) / 2;
                    inputs.Add(outputItem);
                }
            }

        }

        // Generate random ant paths ergo intialise after edges and graph are done and modify the ants stacks with a random selection
        // of the edges
        internal static HashSet<Ant> InitialiseAnts(int antPaths)
        {
            HashSet<Ant> ants = new HashSet<Ant>();
            for (int path = 1; path <= antPaths; path++)
            {
                ants.Add
                (
                    new Ant
                    {
                        AntId = path
                    }
                );
            }
            return ants;
        }
    }
}
