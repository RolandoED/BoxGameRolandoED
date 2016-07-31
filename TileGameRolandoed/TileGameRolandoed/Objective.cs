using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRolandoed
{
    class Objective
    {
        public Objective(int xc, int i)
        {
            // TODO: Complete member initialization
            this.x = xc;
            this.y = i;
        }
        public int x { get; set; }
        public int y { get; set; }        
    }
}
