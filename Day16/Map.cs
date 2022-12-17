using System.Collections.Generic;

namespace Day16
{
    public class Map
    {
        public Dictionary<Valve, Node> Nodes = new();
        public Node Root;
        public Node Target;

        public Map()
        {
            foreach (var valve in Valve.AllValves.Values)
            {
                Nodes.Add(valve, new Node(valve));
            }

            foreach (var node in Nodes.Values)
            {
                foreach (var connection in node.Valve.Connections)
                {
                    node.Connections.Add(Nodes[Valve.AllValves[connection]]);
                }
            }
        }

        public void ResetMap()
        {
            foreach (var node in Nodes)
            {
                node.Value.Previous = null;
                node.Value.Cost = int.MaxValue;
            }
        }
    }
}