using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimize_Building_Stone.Model
{
    public class Polygon
    {
        public List<Node> vertexs { get; set; }
        public Node baseNode { get; set; }

        public Polygon findPolygon(List<Node> nodes, Node baseNode)
        {
            foreach (var line in baseNode.lines)
            {

            }
            return null;
        }
    }

}
