
namespace Day16
{
    public class DualSimulation
    {
        public ValvePath Human;
        public ValvePath Elephant;

        public int minuteForNextHumanMove;
        public int minuteForNextElephantMove;

        public DualSimulation(ValvePath elephant, ValvePath human)
        {
            Human = human;
            Elephant = elephant;
        }
        
        public DualSimulation(Valve elephantStart, Valve humanStart, int elephantCost, int humanCost)
        {
            Human = new ValvePath(humanStart, humanCost, 26);
            Elephant = new ValvePath(elephantStart, elephantCost, 26);
        }
        
        public DualSimulation(DualSimulation copyFrom, Valve next, int cost, bool elephantMove)
        {
            Elephant = elephantMove ? new ValvePath(copyFrom.Elephant, next, cost) : new ValvePath(copyFrom.Elephant);
            Human = elephantMove ? new ValvePath(copyFrom.Human) : new ValvePath(copyFrom.Human, next, cost);
        }

        
        
        public bool ElephantMovesNext()
        {
            return Elephant.RemainingTime > Human.RemainingTime;
        }

        public int Score => Human.Score + Elephant.Score;

        public bool ValveOpen(Valve valve)
        {
            if (Human.Path.Contains(valve))
                return true;
            if (Elephant.Path.Contains(valve))
                return true;
            return false;
        }
    }
}