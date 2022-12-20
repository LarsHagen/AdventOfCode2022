namespace Day19
{
    public class SimulationStep
    {
        public int Step = 0;
        
        public int Ore = 0;
        public int Clay = 0;
        public int Obsidian = 0;
        public int Geode = 0;

        public int OreRobots = 1;
        public int ClayRobots = 0;
        public int ObsidianRobots = 0;
        public int GeodeRobots = 0;
        
        public SimulationStep(){}

        public SimulationStep(SimulationStep copy)
        {
            Ore = copy.Ore;
            Clay = copy.Clay;
            Obsidian = copy.Obsidian;
            Geode = copy.Geode;

            OreRobots = copy.OreRobots;
            ClayRobots = copy.ClayRobots;
            ObsidianRobots = copy.ObsidianRobots;
            GeodeRobots = copy.GeodeRobots;

            Step = copy.Step;
        }

        public void GatherOres()
        {
            Ore += OreRobots;
            Clay += ClayRobots;
            Obsidian += ObsidianRobots;
            Geode += GeodeRobots;
        }
    }
}