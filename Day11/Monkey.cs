using System.Collections.Generic;

namespace Day11
{
    public class Monkey
    {
        public Queue<ulong> currentItems;
        public string operationType;
        public string operationValue;
        public ulong testValue;
        public int monkeyOnTrue;
        public int monkeyOnFalse;
        public ulong inspectionCount = 0;
    }
}