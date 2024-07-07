using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Optimize_Building_Stone.Model;

namespace Optimize_Building_Stone
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************Optimize Building Stone*******************************");
            //Console.WriteLine("Enter input file path:");
            //var inputFilePath = Console.ReadLine();

            string jsonText = File.ReadAllText("C:\\Users\\rezad\\source\\repos\\Optimize Building Stone\\Optimize Building Stone\\Example\\InputLines.json");

            // Deserialize JSON to List<Line>
            List<Line> lines = JsonConvert.DeserializeObject<List<Line>>(jsonText) ?? throw new NullReferenceException("lines file empty");
            List<Line> tempLines = lines;
            List<Node> nodes = new List<Node>();
            List<Polygon> polygons = new List<Polygon>();

            //find nodes  and calculates slop
            foreach (var line in lines!)
            {
                line.doTheThing();
                foreach (var line1 in lines)
                {
                    var node = line.CheckNode(line1);
                    if (node != null)
                    {
                        var same = nodes.Where(nx => nx.lines.Contains(line1) && nx.lines.Contains(line)).ToList();
                        if (same.Count == 0)
                        {
                            nodes.Add(node);
                        }
                    }
                }
            }

            var outputLines = JsonConvert.SerializeObject(lines);
            var outputNodes = JsonConvert.SerializeObject(nodes);

            Console.WriteLine(outputLines);
            Console.WriteLine("*******************************************************************************************");
            Console.WriteLine(outputNodes);
            Console.WriteLine("*******************************************************************************************");
            Console.WriteLine(nodes.Count());



        }
    }
}
