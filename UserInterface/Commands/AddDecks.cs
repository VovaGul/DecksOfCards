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
        private IReadOnlyList<string> paths;
        public IReadOnlyList<string> Paths 
        {
            get => paths;
            set
            {
                CheckPathsExistence(value);
                paths = value;
            } 
        }
        private readonly JsonSerializerSettings settings;

        public AddDecks()
        {
            settings = new JsonSerializerSettings();
            settings.Converters.Add(new DeckConverter());
        }

        public void Run()
        {

            //var settings = new JsonSerializerSettings();
            //settings.Converters.Add(new DeckConverter());

            var decks = GetDecks();
            WriteDecks(decks);
        }



        private void WriteDecks(List<Deck> decks)
        {
            var repository = new StorageDeckRepository();
            foreach (var deck in decks)
            {
                repository.Create(deck);
            }
        }

        private List<Deck> GetDecks()
        {
            return Paths
                .Select(path => new StorageDeckRepository(path, settings).GetAll())
                .SelectMany(x => x)
                .ToList();
        }

        private void CheckPathsExistence(IReadOnlyList<string> paths)
        {
            if (paths.Count == 0)
            {
                throw new InvalidOperationException("Пропущены пути до файлов");
            }
        }
    }
}
