using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    public class Grassfire
    {
        public void Run(Map map)
        {
            Dictionary<(int x, int y), Node> nodes = map.Nodes;
            Node root = map.Root;
            Queue<Node> nodesToCheck = new();
            HashSet<Node> burned = new();

            nodesToCheck.Enqueue(root);

            while (nodesToCheck.Any())
            {
                var currentNode = nodesToCheck.Dequeue();
                List<Node> neighbours = new();

                if (nodes.ContainsKey((currentNode.position.x, currentNode.position.y + 1)))
                {
                    neighbours.Add(nodes[(currentNode.position.x, currentNode.position.y + 1)]);
                }
                if (nodes.ContainsKey((currentNode.position.x, currentNode.position.y - 1)))
                {
                    neighbours.Add(nodes[(currentNode.position.x, currentNode.position.y - 1)]);
                }
                if (nodes.ContainsKey((currentNode.position.x + 1, currentNode.position.y)))
                {
                    neighbours.Add(nodes[(currentNode.position.x + 1, currentNode.position.y)]);
                }
                if (nodes.ContainsKey((currentNode.position.x - 1, currentNode.position.y)))
                {
                    neighbours.Add(nodes[(currentNode.position.x - 1, currentNode.position.y)]);
                }

                var potentialNewDistance = currentNode.Steps(true) + 1;
    
                foreach (var neighbour in neighbours)
                {
                    if (neighbour == root)
                        continue;
        
                    if (neighbour.Height - currentNode.Height > 1)
                        continue;

                    if (neighbour.Steps(false) <= potentialNewDistance)
                        continue;

                    neighbour.Previous = currentNode;
        
                    if (burned.Contains(neighbour))
                        continue;
        
                    if (nodesToCheck.Contains(neighbour))
                        continue;
        
                    nodesToCheck.Enqueue(neighbour);
                }

                burned.Add(currentNode);
            }
        }
    }
}