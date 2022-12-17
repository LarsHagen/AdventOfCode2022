using System.Collections.Generic;
using Day16;

namespace Day16
{
    public class Node
    {
        public Valve Valve;
        public Node Previous;
        public List<Node> Connections = new();
        public int Cost = int.MaxValue;

        public Node(Valve valve)
        {
            Valve = valve;
        }
    }
}