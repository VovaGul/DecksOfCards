using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecksOfCards
{
    public class Deck
    {
        public DeckId Id { get; }
        [JsonProperty]
        private readonly string name;
        private const int maxCountOfCards = 100;
        private List<Card> cards;
        [JsonProperty]
        private List<Card> Cards
        {
            get => cards;
            set
            {
                CheckCountOfCards(value);
                CheckForDuplicates(value);
                CheckForDuplicatesOnSeniorityInSorting(value);
                cards = value;

                isUnverifiedCardsChange = true;
            }
        }
        private bool isUnverifiedCardsChange;
        private bool isSorted;
        [JsonProperty]
        public bool IsSorted
        {
            get
            {
                if (isUnverifiedCardsChange)
                    isSorted = CheckForSorting(Cards);
                isUnverifiedCardsChange = false;

                return isSorted;
            }
        }

        [JsonConstructor]
        private Deck(string name, List<Card> cards, DeckId id)
        {
            Id = id;
            this.name = name;
            Cards = cards;
        }

        private static void CheckCountOfCards(List<Card> cards)
        {
            if (cards.Count > maxCountOfCards)
                throw new ArgumentException
                    ($"Количество карт в колоде превышает допустимый максимум ({maxCountOfCards} шт)");
        }

        private static void CheckForDuplicates(List<Card> verifiedCards)
        {
            if (verifiedCards.Distinct().Count() < verifiedCards.Count)
            {
                throw new ArgumentException
                    ("В колоде присутствуют дубликаты по имени");
            }
        }

        private static void CheckForDuplicatesOnSeniorityInSorting(List<Card> verifiedCards)
        {
            if (verifiedCards.Select(x => x.SeniorityInSorting).Distinct().Count() < verifiedCards.Count)
            {
                throw new ArgumentException
                    ("В колоде присутствуют дубликаты по порядку сортировки");
            }
        }

        private bool CheckForSorting(List<Card> verifiedCards)
        {
            return verifiedCards.SequenceEqual(SortAscending(verifiedCards));
        }

        public Deck Mix()
        {
            MixList(Cards);
            return this;
        }

        private void MixList(List<Card> cards)
        {
            var random = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public Deck SortAscending()
        {

            Cards = SortAscending(Cards);
            return this;
        }

        private static List<Card> SortAscending(List<Card> decks)
        {
            return decks.OrderBy(x => x).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Имя: {name}");
            sb.AppendLine($"Количество карт: {Cards.Count}");
            sb.AppendLine($"Колода сортирована: {IsSorted}");
            sb.AppendLine($"Cards:");
            foreach (var card in Cards)
            {
                sb.AppendLine(card.ToString());
            }

            return sb.ToString();
        }
    }
}
