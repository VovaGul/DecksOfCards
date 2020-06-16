using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DecksOfCards
{
    public class Card : IEquatable<Card>, IComparable
    {
        [JsonProperty]
        private readonly string name;
        public int SeniorityInSorting { get; }

        public Card(string name, int seniorityInSorting)
        {
            this.name = name;
            SeniorityInSorting = seniorityInSorting;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Card);
        }

        public bool Equals(Card other)
        {
            if (other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(name);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Card otherCard)
                return SeniorityInSorting.CompareTo(otherCard.SeniorityInSorting);
            else
                throw new ArgumentException("Объект не является экземпляром класса Card");
        }

        public override string ToString()
        {
            return name.ToString();
        }
    }
}
