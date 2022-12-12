namespace Day12
{
    public class Node
    {
        public char Height;
        public (int x, int y) position;
        public Node Previous;

        public Node(Node previous, int x, int y)
        {
            Previous = previous;
            position.x = x;
            position.y = y;
        }
        
        public Node(char height, int x, int y)
        {
            Height = height;
            position.x = x;
            position.y = y;
        }

        public int Steps(bool allowNull)
        {
            if (!allowNull && Previous == null)
                return int.MaxValue;
            
            int steps = 0;
            Node parent = Previous;
            while (parent != null)
            {
                parent = parent.Previous;
                steps++;
            }

            return steps;
        }
    }
}