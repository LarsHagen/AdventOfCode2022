using System;
using System.Collections.Generic;

namespace Day19
{
    public class Simulate
    {
        private Stack<SimulationStep> stepsToRun = new();

        public int Run(Blueprint blueprint, int steps = 24)
        {
            stepsToRun.Clear();
            int best = 0;
            
            stepsToRun.Push(new SimulationStep());

            int mostExpensiveOreRobot = blueprint.OreRobotCost;
            mostExpensiveOreRobot = Math.Max(mostExpensiveOreRobot, blueprint.ClayRobotCost);
            mostExpensiveOreRobot = Math.Max(mostExpensiveOreRobot, blueprint.GeodeRobotCost.Item1);
            mostExpensiveOreRobot = Math.Max(mostExpensiveOreRobot, blueprint.ObsidianRobotCost.Item1);

            int oreClayRatio = blueprint.ObsidianRobotCost.Item2 / blueprint.ObsidianRobotCost.Item1;
            int oreObsidianRatio = blueprint.GeodeRobotCost.Item2 / blueprint.GeodeRobotCost.Item1;

            while (stepsToRun.Count > 0)
            {
                var step = stepsToRun.Pop();

                if (step.Geode > best)
                {
                    best = step.Geode;
                    //Console.WriteLine($"{step.Ore}, {step.Clay}, {step.Obsidian}, {step.Geode}... {step.OreRobots}, {step.ClayRobots}, {step.ObsidianRobots}, {step.GeodeRobots}");
                    Console.WriteLine("Found new best " + best);
                }
                    
                if (step.Step == steps)
                {
                    continue;
                }

                int highestPossibleScoreFromHere = step.Geode;
                int simulatedGeodeRobots = step.GeodeRobots;
                for (int i = step.Step; i <= steps; i++)
                {
                    highestPossibleScoreFromHere += simulatedGeodeRobots;
                    simulatedGeodeRobots++;
                }
                if (highestPossibleScoreFromHere < best)
                    continue;
                
                
                bool buildGeodeRobot = false;
                bool buildObsidianRobot = false;
                bool buildClayRobot = false;
                bool buildOreRobot = false;
                
                if (step.Ore >= blueprint.GeodeRobotCost.Item1 && step.Obsidian >= blueprint.GeodeRobotCost.Item2)
                {
                    buildGeodeRobot = true;
                }
                else //No need to simulate other builds. If we can build a geode robot then that is always the right move
                {
                    //int maxClayRobots = step.OreRobots * oreClayRatio;
                    //int maxObsidianRobots = step.OreRobots * oreObsidianRatio;
                    int maxClayRobots = blueprint.ObsidianRobotCost.Item2;
                    int maxObsidianRobots = blueprint.GeodeRobotCost.Item2;
                        
                    if (step.ObsidianRobots < maxObsidianRobots &&
                        step.Ore >= blueprint.ObsidianRobotCost.Item1 && step.Clay >= blueprint.ObsidianRobotCost.Item2)
                    {
                        buildObsidianRobot = true;
                    }

                    if (step.ClayRobots < maxClayRobots && step.Ore >= blueprint.ClayRobotCost)
                    {
                        buildClayRobot = true;
                    }

                    if (step.OreRobots < mostExpensiveOreRobot && step.Ore >= blueprint.OreRobotCost)
                    {
                        buildOreRobot = true;
                    }
                }

                step.GatherOres();
                step.Step++;
                
                if (buildOreRobot)
                {
                    var next = new SimulationStep(step);
                    next.Ore -= blueprint.OreRobotCost;
                    next.OreRobots++;
                    stepsToRun.Push(next);
                }
                
                if (buildClayRobot)
                {
                    var next = new SimulationStep(step);
                    next.Ore -= blueprint.ClayRobotCost;
                    next.ClayRobots++;
                    stepsToRun.Push(next);
                }
                if (buildObsidianRobot)
                {
                    var next = new SimulationStep(step);
                    next.Ore -= blueprint.ObsidianRobotCost.Item1;
                    next.Clay -= blueprint.ObsidianRobotCost.Item2;
                    next.ObsidianRobots++;
                    stepsToRun.Push(next);
                }
                if (buildGeodeRobot)
                {
                    var next = new SimulationStep(step);
                    next.Ore -= blueprint.GeodeRobotCost.Item1;
                    next.Obsidian -= blueprint.GeodeRobotCost.Item2;
                    next.GeodeRobots++;
                    stepsToRun.Push(next);
                }
                
                
                
                //if (step.Step < 15 || (!buildClayRobot && !buildGeodeRobot && !buildObsidianRobot && !buildOreRobot))
                //if (!buildClayRobot && !buildGeodeRobot && !buildObsidianRobot && !buildOreRobot)
                //if (!buildObsidianRobot && !buildGeodeRobot)
                if (!buildGeodeRobot)
                    stepsToRun.Push(step);
            }

            return best;
        }
    }
}