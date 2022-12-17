using System.Collections.Generic;

namespace Day16
{
    public class ValvePathPart2
    {
        public readonly List<Valve> PathElephant = new();
        public readonly List<Valve> PathYou = new();
        public int RemainingTime;
        public int Score;

        public List<string> History = new();

        public ValvePathPart2(Valve startYou, Valve startElephant, int cost)
        {
            PathYou.Add(startYou);
            PathElephant.Add(startElephant);
            RemainingTime = (26 - cost) - 1;
            Score = startYou.FlowRate * RemainingTime;
            Score += startElephant.FlowRate * RemainingTime;

            //History.Add($"Moved to {start.Name}. Releasing {start.FlowRate} for a score of {Score}. Remaining time {RemainingTime}");
        }
        
        public ValvePathPart2(ValvePathPart2 copyFrom, Valve nextYou, Valve nextElephant, int cost)
        {
            RemainingTime = copyFrom.RemainingTime - cost;
            RemainingTime--;
            
            PathYou = new List<Valve>(copyFrom.PathYou);
            PathYou.Add(nextYou);
            Score = copyFrom.Score + nextYou.FlowRate * RemainingTime;
            
            PathElephant = new List<Valve>(copyFrom.PathElephant);
            PathElephant.Add(nextElephant);
            Score = copyFrom.Score + nextElephant.FlowRate * RemainingTime;
            
            //History = new List<string>(copyFrom.History);
            //History.Add($"Moved to {next.Name}. Releasing {next.FlowRate} for a score of {Score}. Remaining time {RemainingTime}");
        }
    }
}