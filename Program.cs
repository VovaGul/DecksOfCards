using Binateq.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace DecksOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = Parser.Command<ICommand, Get>("get", "g")
                                .Nonamed(x => x.Identifiers)
                       | Parser.Command<ICommand, GetAll>("getall", "gl")
                       | Parser.Command<ICommand, Mix>("mix", "m")
                                .Nonamed(x => x.Identifiers)
                       | Parser.Command<ICommand, Sort>("sort", "s")
                                .Nonamed(x => x.Identifiers)
                       | Parser.Default<ICommand, Help>("help", "h")
                                .Nonamed(x => x.CommandName);

            var command = parser.Parse(args);
            try
            {
                command.Run();
            }
            catch (InvalidOperationException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
            }

            var TarotDeck = new Deck(
                "Таро",
                new List<Card>
                {
                        new Card("7 Трефы", 5),
                        new Card("2 Черви", 2),
                        new Card("0 Шут", 54)
                });
            var UnoDeck = new Deck(
                "Уно",
                new List<Card>
                {
                        new Card("5 желтая", 25),
                        new Card("2 синяя", 4),
                        new Card("+4 синий", 40),
                        new Card("любое действие", 50),
                });

            var deckRepository = new StorageDeckRepository();

            deckRepository.Create(TarotDeck);
            deckRepository.Create(UnoDeck);
            deckRepository.Read(1487599935);
        }
    }
}
