namespace Optimize_Building_Stone.Model
{
    public class Node
    {
        public int Id { get; set; }
        public Point point { get; set; }
        public List<Line> lines { get; set; }

        public Node(List<Line> linesInput, Point pointInput)
        {
            lines = linesInput;
            point = pointInput;
        }
    }
}
