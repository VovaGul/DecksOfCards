using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DecksOfCards.UserInterface.Commands
{
    class AddDecks : ICommand
    {
        public IReadOnlyList<string> Paths { get; set; }
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings();

        public AddDecks()
        {
            settings.Converters.Add(new DeckConverter());
        }

        public void Run()
        {
            if (Paths.Count == 0)
            {
                throw new InvalidOperationException("Пропущены пути до файлов");
            }

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new DeckConverter());

            var decks = Paths
                .Select(path => new StorageDeckRepository(path, settings).GetAll())
                .SelectMany(x => x)
                .ToList();
            var repository = new StorageDeckRepository();
            foreach (var deck in decks)
            {
                repository.Create(deck);
            }



        }
    }
}
