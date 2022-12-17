using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public class Grassfire
    {
        public static void Run(Map map)
        {
            Node root = map.Root;
            Queue<Node> nodesToCheck = new();
            HashSet<Node> burned = new();

            nodesToCheck.Enqueue(root);

            while (nodesToCheck.Any())
            {
                var currentNode = nodesToCheck.Dequeue();
                List<Node> neighbours = currentNode.Connections;

                foreach (var neighbour in neighbours)
                {
                    if (neighbour == root)
                        continue;
                    
                    if (currentNode.Cost + 1 >= neighbour.Cost)
                        continue;

                    neighbour.Cost = currentNode.Cost + 1;
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