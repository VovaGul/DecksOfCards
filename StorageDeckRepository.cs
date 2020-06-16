using System;
using System.Collections.Generic;
using System.Linq;

namespace DecksOfCards
{
    public class StorageDeckRepository : IRepository
    {
        private readonly IStorage storage = new JSONFileStorage();

        public void Create(Deck deck)
        {
            var decks = storage.Read();
            decks.Add(deck);
            storage.Write(decks);
        }

        public Deck Read(int id)
        {
            var decks = storage.Read();
            Deck deck;
            try
            {
                deck = decks.First(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Не существует элемента с Id={id}");
            }
            return deck;
        }

        public void Update(Deck deck)
        {
            var decks = storage.Read();
            for (int i = 0; i < decks.Count; i++)
            {
                if (decks[i].Id == deck.Id)
                {
                    decks[i] = deck;
                    storage.Write(decks);
                    return;
                }
            }
            throw new InvalidOperationException($"Не существует элемента с Id={deck.Id}");
        }

        public void Delete(int id)
        {
            var decks = storage.Read();
            for (int i = 0; i < decks.Count; i++)
            {
                if (decks[i].Id == id)
                {
                    decks.RemoveAt(id);
                }
            }
            storage.Write(decks);
        }

        public List<Deck> GetAll()
        {
            var decks = storage.Read();
            return decks;
        }
    }
}
