using System;
using System.Collections.Generic;

namespace Project05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');

            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways
            List<Connection> links = new List<Connection>();
            for (int x = 0; x < L; x++)
            {
                inputs = Console.ReadLine().Split(' ');
                links.Add(new Connection(int.Parse(inputs[0]), int.Parse(inputs[1])));
            }
            List<int> gateways = new List<int>();
            for (int x = 0; x < E; x++)
                gateways.Add(int.Parse(Console.ReadLine()));

            // game loop
            while (true)
            {
                int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

                Connection.CloseGateway(SI, gateways, links);
            }
        }

        public class Connection
        {
            //declaring the private member integers
            private int Vertex1 { get; set; }

            private int Vertex2 { get; set; }

            public Connection(int vertex1, int vertex2)
            {
                this.Vertex1 = vertex1;
                Vertex2 = vertex2;
            }

            public override string ToString()
            {
                return $"{Vertex1} {Vertex2}";
            }

            public override bool Equals(object obj)
            {
                //casting link as connection
                Connection link = obj as Connection;
                return (Vertex1 == link.Vertex1 && Vertex2 == link.Vertex2) || (Vertex1 == link.Vertex2 && Vertex2 == link.Vertex1);
            }

            static public void CloseGateway(int agentIndex, List<int> gateways, List<Connection> links)
            {
                foreach (int gateway in gateways)
                {
                    Connection link = new Connection(agentIndex, gateway);
                    if (links.Contains(link))
                    {
                        Console.WriteLine(link);
                        links.Remove(link);
                        return;
                    }
                }
                Console.WriteLine(links[new Random().Next(0, links.Count)]);
            }
        }
    }
}