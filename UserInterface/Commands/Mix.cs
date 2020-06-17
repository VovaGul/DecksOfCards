using System.Linq;

namespace DecksOfCards
{
    class Mix : CommandWithIdentifiers
    {
        public override void Run()
        {
            var repository = new StorageDeckRepository();
            var decks = Identifiers
                .Select(id => ParseId(id))
                .Select(id => repository.Read(id))
                .Select(deck => deck.Mix());
            foreach (var deck in decks)
            {
                repository.Update(deck);
            }
        }
    }
}
