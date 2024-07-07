using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimize_Building_Stone.Model
{
    public class Polysurface
    {
        public int edgeNumber {  get; set; }
        public List<Line> edge {  get; set; }
    }
}
