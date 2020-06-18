using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DecksOfCards
{
    public struct DeckId : IEquatable<DeckId>, IEquatable<int>
    {
        [JsonProperty]
        private readonly int id;

        [JsonConstructor]
        private DeckId(int id)
        {
            this.id = id;
        }

        public static DeckId GenerateId()
        {
            var random = new Random();
            var id = random.Next();
            return new DeckId(id);
        }

        public override bool Equals(object other)
        {
            if (other == null ||
                !GetType().Equals(other.GetType()))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Equals((DeckId)other);
        }

        public bool Equals(DeckId other)
        {
            if (other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return id == other.id;
        }

        public bool Equals(int other)
        {
            return id == other;
        }

        public static bool operator ==(DeckId deckId1, DeckId deckId2)
        {
            if (deckId1.Equals(deckId2))
                return true;
            return false;
        }

        public static bool operator !=(DeckId deckId1, DeckId deckId2)
        {
            if (!deckId1.Equals(deckId2))
                return true;
            return false;
        }

        public static bool operator ==(DeckId deckId1, int deckId2)
        {
            return deckId1.Equals(deckId2);
        }

        public static bool operator !=(DeckId deckId1, int deckId2)
        {
            return !deckId1.Equals(deckId2);
        }

        public static implicit operator int(DeckId d) => d.id;

        public override string ToString()
        {
            return id.ToString();
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<int>.Default.GetHashCode(id);
        }
    }
}
