using Optimize_Building_Stone.Model.Enums;


namespace Optimize_Building_Stone.Model
{
    public class Line
    {
        public int Id { get; set; }
        public Point? startPoint { get; set; }
        public Point? endPoint { get; set; }
        //line formula by = ax + c => y = Ax + C
        // A = a/b   , C = c/b
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public LineType type { get; set; }

        public void doTheThing()
        {
            if (startPoint!.y == endPoint!.y)
            {
                type = LineType.Horizontal;
                a = 0;
                b = 1;
                c = endPoint.y;
            }
            else if (startPoint!.x == endPoint!.x)
            {
                type = LineType.Vertical;
                a = 1;
                b = 0;
                c = 0 - endPoint.x;
            }
            else
            {
                type = LineType.NonVerticalNonHorizontal;
                a = (endPoint.y - startPoint.y) / (endPoint.x - startPoint.x);
                c = startPoint.y - a * startPoint.x;
                b = 1;
            }

        }

        public Node? CheckNode(Line line)
        {
            if (a == line.a || (line.type == this.type && this.type != LineType.NonVerticalNonHorizontal))
            {
                return null;
            }
            else
            {

                var newPoint = new Point();
                newPoint.x = (c - line.c) / (a - line.a);
                newPoint.y = a * newPoint.x + c;
                List<Line> lines = new List<Line>();
                lines.Add(line);
                lines.Add(this);
                return new Node(lines, newPoint);
            }
        }
    }
}
