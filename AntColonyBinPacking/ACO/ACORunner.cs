using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO.Enumerations;
using AntColonyBinPacking.ACO.Interfaces;
using AntColonyBinPacking.ACO;

namespace AntColonyBinPacking
{
    class ACORunner
    {
        public static readonly int BinAmount = 10;
        public static readonly double EvaporationRate = 0.9;
        public static readonly int AntPaths = 10;

        // First test 10 ant paths so 10 ants, 0.9 eval, 500 random items weight at i into 10 bins
        public static void Main(string[] args)
        {
            List<double> inputItems = new List<double>();
            ACOHelper.InitialiseInputItems(inputItems, (int)BinProblemsEnum.BPP1);
            List<Edge> edges = ACOHelper.InitialiseEdges(BinAmount * inputItems.Count);

            IConstructionGraph binGraph = new ConstructionGraph
            {
                BinLevels = BinAmount,
                GraphEdges = edges
            };

            Console.ReadLine();   //Ensures the terminal window remains open.
        }
    }
}
