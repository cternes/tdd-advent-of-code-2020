namespace app
{
    using System.Collections.Generic;
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
            spokenNumberHistory.TryGetValue(new SpokenNumber(result), out var spokenNumber);
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
            spokenNumberHistory.TryGetValue(new SpokenNumber(spokenNumberInPreviousTurn), out var spokenNumber);
            var result = spokenNumber!.DiffSpokenTurnsBefore;
            spokenNumber.SpokenAt(turnCounter);

            return result;
        }

        private bool NotAllStartingNumbersWereSpoken()
        {
            return turnCounter < startingNumbers.Count;
        }
    }
}