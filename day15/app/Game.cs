namespace app
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class Game
    {
        private int previousResult;
        private int turn;
        private readonly HashSet<SpokenNumber> history = new();
        private readonly List<int> startingNumbers;

        public Game(List<int> startingNumbers)
        {
            this.startingNumbers = startingNumbers;
        }

        public int Play()
        {
            if (turn < startingNumbers.Count)
            {
                var result = startingNumbers[turn];
                turn++;
                history.Add(new SpokenNumber(result, turn));
                previousResult = result;
                return result;
            }

            var spokenNumber = history.First(i => i.Value == previousResult);
            previousResult = spokenNumber.DiffSpokenTurnsBefore;
            spokenNumber.SpokenAt(turn);
            turn++;

            history.TryGetValue(new SpokenNumber(previousResult, turn), out var x);
            if (x != null)
            {
                x.SpokenAt(turn);
            }
            else
            {
                history.Add(new SpokenNumber(previousResult, turn));
            }

            return previousResult;
        }
    }
}