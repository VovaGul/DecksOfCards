using System;
using System.Linq;

namespace DecksOfCards
{
    class Get : CommandWithIdentifiers
    {
        public override void Run()
        {
            CheckIdentifiersExistence();
            PrintDecks();
        }

        private void PrintDecks()
        {
            var decksStrings = Identifiers
                .Select(id => ParseId(id))
                .Select(id => 
                new StorageDeckRepository().Read(id).ToString());
            Console.WriteLine(string.Join("\r\n", decksStrings));
        }
    }
}
