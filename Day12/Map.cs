using System.Collections.Generic;

namespace Day12
{
    public class Map
    {
        public Dictionary<(int x, int y), Node> Nodes;
        public Node Root;
        public Node Target;

        public Map(string[] lines)
        {
            int mapWidth = lines[0].Length;
            int mapHeight = lines.Length;
            Nodes = new();
            Root = new(null, 0,0);
            Target = new(null, 0,0);

            for (int y = 0; y < mapHeight; y++)
            {
                var currentLine = lines[y];
                for (int x = 0; x < mapWidth; x++)
                {
                    var currentChar = currentLine[x];

                    if (currentChar == 'S')
                    {
                        Root = new Node('a', x, y);
                        Nodes.Add(Root.position, Root);
                    }
                    else if (currentChar == 'E')
                    {
                        Target = new Node('z', x, y);
                        Nodes.Add(Target.position, Target);
                    }
                    else
                    {
                        Nodes.Add((x,y), new Node(currentChar, x, y));
                    }
                }
            }
        }

        public void ResetMap()
        {
            foreach (var node in Nodes)
            {
                node.Value.Previous = null;
            }
        }
    }
}