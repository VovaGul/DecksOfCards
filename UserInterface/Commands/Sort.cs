using System.Collections.Generic;
using System.Linq;

namespace DecksOfCards
{
    class Sort : CommandWithIdentifiers
    {
        public override void Run()
        {
            var repository = new StorageDeckRepository();
            var decks = Identifiers
                .Select(id => ParseId(id))
                .Select(id => repository.Read(id))
                .Select(deck => deck.SortAscending());
            foreach (var deck in decks)
            {
                repository.Update(deck);
            }
        }
    }
}
