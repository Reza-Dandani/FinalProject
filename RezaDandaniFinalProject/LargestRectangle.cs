//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;

//public class Program
//{
//    public static void Main()
//    {
//        // Define the polygon as a list of points
//        List<PointF> polygon = new List<PointF>
//        {
//            new PointF(0, 0),
//            new PointF(5, 0),
//            new PointF(5, 3),
//            new PointF(2, 6),
//            new PointF(0, 3)
//        };

//        // Find the largest rectangle
//        RectangleF largestRectangle = FindLargestRectangle(polygon);

//        Console.WriteLine("Largest Rectangle:");
//        Console.WriteLine($"X: {largestRectangle.X}, Y: {largestRectangle.Y}");
//        Console.WriteLine($"Width: {largestRectangle.Width}, Height: {largestRectangle.Height}");
//    }

//    public static RectangleF FindLargestRectangle(List<PointF> polygon)
//    {
//        RectangleF boundingBox = GetBoundingBox(polygon);
//        float maxArea = 0;
//        RectangleF maxRect = RectangleF.Empty;

//        float stepSize = 0.1f; // Adjust step size for finer or coarser search

//        for (float x = boundingBox.Left; x <= boundingBox.Right; x += stepSize)
//        {
//            for (float y = boundingBox.Top; y <= boundingBox.Bottom; y += stepSize)
//            {
//                for (float width = stepSize; width <= boundingBox.Right - x; width += stepSize)
//                {
//                    for (float height = stepSize; height <= boundingBox.Bottom - y; height += stepSize)
//                    {
//                        RectangleF rect = new RectangleF(x, y, width, height);

//                        if (IsRectangleInsidePolygon(rect, polygon))
//                        {
//                            float area = rect.Width * rect.Height;
//                            if (area > maxArea)
//                            {
//                                maxArea = area;
//                                maxRect = rect;
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        return maxRect;
//    }

//    public static RectangleF GetBoundingBox(List<PointF> polygon)
//    {
//        float minX = polygon.Min(p => p.X);
//        float minY = polygon.Min(p => p.Y);
//        float maxX = polygon.Max(p => p.X);
//        float maxY = polygon.Max(p => p.Y);

//        return new RectangleF(minX, minY, maxX - minX, maxY - minY);
//    }

//    public static bool IsRectangleInsidePolygon(RectangleF rect, List<PointF> polygon)
//    {
//        // Check if all four corners of the rectangle are inside the polygon
//        PointF[] corners = new PointF[]
//        {
//            new PointF(rect.Left, rect.Top),
//            new PointF(rect.Right, rect.Top),
//            new PointF(rect.Right, rect.Bottom),
//            new PointF(rect.Left, rect.Bottom)
//        };

//        foreach (PointF corner in corners)
//        {
//            if (!IsPointInPolygon(corner, polygon))
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//    public static bool IsPointInPolygon(PointF point, List<PointF> polygon)
//    {
//        bool isInside = false;
//        int n = polygon.Count;
//        for (int i = 0, j = n - 1; i < n; j = i++)
//        {
//            if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
//                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
//            {
//                isInside = !isInside;
//            }
//        }

//        return isInside;
//    }

//    // Optional: Visualize the polygon and the largest rectangle (requires System.Windows.Forms and System.Drawing)
//    public static void Visualize(List<PointF> polygon, RectangleF largestRectangle)
//    {
//        using (var bmp = new Bitmap(500, 500))
//        {
//            using (var g = Graphics.FromImage(bmp))
//            {
//                g.Clear(Color.White);

//                // Draw the polygon
//                g.DrawPolygon(Pens.Black, polygon.ToArray());

//                // Draw the largest rectangle
//                g.DrawRectangle(Pens.Red, largestRectangle.X, largestRectangle.Y, largestRectangle.Width, largestRectangle.Height);
//            }

//            bmp.Save("largestRectangle.png");
//        }

//        Console.WriteLine("Visualization saved as largestRectangle.png");
//    }
//}
