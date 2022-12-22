using System;
using System.Collections.Generic;

namespace Day21
{
    public interface IExpression
    {
        string A { get; set; }
        string B { get; set; }
        long Eval(long valueA, long valueB);
        long GetB(long equals, long valueA);
        long GetA(long equals, long valueB);
    }
    
    public class Add : IExpression
    {
        public string A { get; set; }
        public string B { get; set; }

        public long Eval(long valueA, long valueB)
        {
            return valueA + valueB;
        }

        public long GetB(long equals, long valueA)
        {
            return equals - valueA;
        }
        
        public long GetA(long equals, long valueB)
        {
            return equals - valueB;
        }
    }
    
    public class Substract : IExpression
    {
        public string A { get; set; }
        public string B { get; set; }

        public long Eval(long valueA, long valueB)
        {
            return valueA - valueB;
        }
        
        public long GetA(long equals, long valueB)
        {
            return equals + valueB;
        }

        public long GetB(long equals, long valueA)
        {
            return -1 * (equals - valueA);
        }
    }
    
    public class Multiply : IExpression
    {
        public string A { get; set; }
        public string B { get; set; }

        public long Eval(long valueA, long valueB)
        {
            return valueA * valueB;
        }
        
        public long GetA(long equals, long valueB)
        {
            return equals / valueB;
        }
        
        public long GetB(long equals, long valueA)
        {
            return equals / valueA;
        }
    }
    
    public class Divide : IExpression
    {
        public string A { get; set; }
        public string B { get; set; }

        public long Eval(long valueA, long valueB)
        {
            return valueA / valueB;
        }
        
        public long GetA(long equals, long valueB)
        {
            return equals * valueB;
        }
        
        public long GetB(long equals, long valueA)
        {
            return valueA / equals;
        }
    }
}