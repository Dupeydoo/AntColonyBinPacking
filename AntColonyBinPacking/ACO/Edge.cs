using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyBinPacking.ACO
{
    public class Edge
    {
        public int EdgeId { get; set; }
        public int PheromoneValue { get; set; }
        public int EndNode_BinNumber { get; set; }
    }
}
