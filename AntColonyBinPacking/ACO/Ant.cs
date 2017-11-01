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
    }
}
