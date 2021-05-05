namespace app.Model
{
    using System;

    public class SpokenNumber : IEquatable<SpokenNumber>
    {
        private const int NotSpoken = -1;

        public int Value { get; init; }

        private int recentlySpokenAt;

        private int penultimatelySpokenAt = NotSpoken;

        public int DiffSpokenTurnsBefore
        {
            get
            {
                if (penultimatelySpokenAt == NotSpoken)
                {
                    return 0;
                }

                return recentlySpokenAt - penultimatelySpokenAt;
            }
        }

        public SpokenNumber(int value, int turn)
        {
            Value = value;
            recentlySpokenAt = turn;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public void SpokenAt(int turn)
        {
            penultimatelySpokenAt = recentlySpokenAt;
            recentlySpokenAt = turn;
        }

        public bool Equals(SpokenNumber? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SpokenNumber) obj);
        }
    }
}