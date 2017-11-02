using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO.ACOCommon
{
    public static class AntMaths
    {
        public static double GenerateRandomDouble(Random random)
        {
            double rand = random.Next();
            return 1 - (rand / int.MaxValue);
        }
    }
}
