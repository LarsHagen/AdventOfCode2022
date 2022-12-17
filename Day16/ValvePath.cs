using System.Collections.Generic;

namespace Day16
{
    public class ValvePath
    {
        public readonly List<Valve> Path = new();
        public int RemainingTime;
        public int Score;

        public List<string> History = new();

        public ValvePath(Valve start, int cost)
        {
            Path.Add(start);
            RemainingTime = (30 - cost) - 1;
            Score = start.FlowRate * RemainingTime;

            History.Add($"Moved to {start.Name}. Releasing {start.FlowRate} for a score of {Score}. Remaining time {RemainingTime}");
        }
        
        public ValvePath(ValvePath copyFrom, Valve next, int cost)
        {
            RemainingTime = copyFrom.RemainingTime - cost;
            RemainingTime--;
            Path = new List<Valve>(copyFrom.Path);
            Path.Add(next);
            Score = copyFrom.Score + next.FlowRate * RemainingTime;
            History = new List<string>(copyFrom.History);
            History.Add($"Moved to {next.Name}. Releasing {next.FlowRate} for a score of {Score}. Remaining time {RemainingTime}");
        }
    }
}