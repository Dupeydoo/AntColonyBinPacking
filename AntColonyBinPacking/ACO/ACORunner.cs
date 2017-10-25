using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonyBinPacking.ACO.Enumerations;

namespace AntColonyBinPacking
{
    class ACORunner
    {
        public int BinAmount { get; set; }

        // First test 10 ant paths so 10 ants, 0.9 eval, 500 random items weight at i into 10 bins
        public static void Main(string[] args)
        {
            List<double> inputItems = new List<double>();
            InitialiseInputItems(inputItems, (int)BinProblemsEnum.BPP1);
            Console.ReadLine();   //Ensures the terminal window remains open.
        }

        private static void InitialiseInputItems(List<double> inputs, int binPackingProblem)
        {
            if(binPackingProblem == 0)
            {
                for (int item = 1; item <= 500; item++)
                {
                    inputs.Add(item);
                    Console.Write("{0} ", item);
                }
            }

            else if(binPackingProblem == 1)
            {
                for(int item = 1; item <= 500; item++)
                {
                    double outputItem = Math.Pow(item, 2) / 2;
                    inputs.Add(outputItem);
                    Console.Write("{0} ", outputItem);
                }
            }
            
        }
    }
}
