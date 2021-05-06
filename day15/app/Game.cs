namespace app
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class Game
    {
        private int spokenNumberInPreviousTurn;
        private int turnCounter;
        private readonly HashSet<SpokenNumber> spokenNumberHistory = new();
        private readonly List<int> startingNumbers;

        public Game(List<int> startingNumbers)
        {
            this.startingNumbers = startingNumbers;
        }

        public int Play()
        {
            var result = CalculateResult();
            IncreaseTurnCounter();

            StoreThatNumberWasSpokenThisTurn(result);
            WriteResultHistory(result);
            
            return result;
        }

        private void StoreThatNumberWasSpokenThisTurn(int result)
        {
            var spokenNumber = spokenNumberHistory.FirstOrDefault(i => i.Value == result);
            spokenNumber?.SpokenAt(turnCounter);
        }

        private void IncreaseTurnCounter()
        {
            turnCounter++;
        }

        private void WriteResultHistory(int result)
        {
            spokenNumberHistory.Add(new SpokenNumber(result, turnCounter));
            spokenNumberInPreviousTurn = result;
        }

        private int CalculateResult()
        {
            if (NotAllStartingNumbersWereSpoken())
            {
                return startingNumbers[turnCounter];
            }

            return GetSpokenNumberFromHistory();
        }

        private int GetSpokenNumberFromHistory()
        {
            var spokenNumber = spokenNumberHistory.First(i => i.Value == spokenNumberInPreviousTurn);
            var result = spokenNumber.DiffSpokenTurnsBefore;
            spokenNumber.SpokenAt(turnCounter);

            return result;
        }

        private bool NotAllStartingNumbersWereSpoken()
        {
            return turnCounter < startingNumbers.Count;
        }
    }
}