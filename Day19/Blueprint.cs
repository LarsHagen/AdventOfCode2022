using System;
using System.Linq;

namespace Day19
{
    public class Blueprint
    {
        public int OreRobotCost; //Price in ore
        public int ClayRobotCost; //Price in clay
        public (int, int) ObsidianRobotCost; //Price in Ore/Clay
        public (int, int) GeodeRobotCost; //Price in Ore/Obsidian

        public Blueprint(string input)
        {
            //Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
            var cleaned = input
                .Replace("Blueprint ", null)
                .Replace(" Each ore robot costs ", null)
                .Replace(" Each clay robot costs ", null)
                .Replace(" Each obsidian robot costs ", null)
                .Replace(" Each geode robot costs ", null)
                .Replace(" ore and ", ".")
                .Replace(" ore.", ".")
                .Replace(" clay.", ".")
                .Replace(" obsidian.", null);
            //1:4.2.3.14.2.7
            var costs = cleaned.Split(":")[1].Split(".").Select(i => int.Parse(i)).ToArray();

            OreRobotCost = costs[0];
            ClayRobotCost = costs[1];
            ObsidianRobotCost = (costs[2],costs[3]);
            GeodeRobotCost = (costs[4],costs[5]);
        }
    }
}