using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    public class Valve
    {
        public string[] Connections;
        public string Name;
        public int FlowRate;
        
        public static Dictionary<string,Valve> AllValves = new();

        public Dictionary<Valve, int> CostToMoveToOtherValveWithFlow = new();

        public Valve(string input)
        {
            input = input
                .Replace("Valve ", null)
                .Replace(" has flow rate", null)
                .Replace(" tunnels lead to valves ", null)
                .Replace(" tunnel leads to valve ", null)
                .Replace(" ", null);

            var split = input.Split(";");
            
            Connections = split[1].Split(",");
            Name = split[0].Split("=")[0];
            FlowRate = int.Parse(split[0].Split("=")[1]);
            
            AllValves.Add(Name, this);
        }

        public void CalculatePathsToOtherValvesWithFlow()
        {
            Console.WriteLine("");
            Console.WriteLine("From " + Name);
            
            Map map = new Map();
            map.Root = map.Nodes[this];

            var targets = AllValves.Values.Where(v => v.FlowRate != 0 && v != this);
            foreach (var target in targets)
            {
                map.ResetMap();
                map.Root.Cost = 0;
                map.Target = map.Nodes[target];
                Grassfire.Run(map);

                Console.WriteLine("To " + target.Name + ". Time: " + map.Target.Cost);
                
                CostToMoveToOtherValveWithFlow.Add(target, map.Target.Cost);
            }
        }
    }
}