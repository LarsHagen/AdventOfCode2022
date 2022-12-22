namespace Day20
{
    public class Node
    {
        public Node Previous;
        public Node Next;
        public long Value;
        public static Node Start;

        public void MoveForward()
        {
            if (Start == Next)
            {
                //Start = this;
            }
            else if (Start == this)
            {
                Start = Next;
            }

            var p = Next;
            var n = Next.Next;
            
            Next.Previous = Previous;
            Previous.Next = Next;
            Next.Next.Previous = this;
            Next.Next = this;

            Previous = p;
            Next = n;
        }

        public void MoveBack()
        {
            
            if (Start == Previous)
            {
                //Start = this;
            }
            else if (Start == this)
            {
                Start = Next;
            }
            
            var p = Previous.Previous;
            var n = Previous;
            
            Next.Previous = Previous;
            Previous.Next = Next;
            Previous.Previous.Next = this;
            Previous.Previous = this;

            Previous = p;
            Next = n;
        }
    }
}