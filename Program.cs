using Binateq.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace DecksOfCards
{
    class Program
    {
        private static readonly Parser<ICommand> parser = Parser.Command<ICommand, Get>("get", "g")
                                                                 .Nonamed(x => x.Identifiers)
                                                        | Parser.Command<ICommand, GetAll>("getall", "gl")
                                                        | Parser.Command<ICommand, Mix>("mix", "m")
                                                                 .Nonamed(x => x.Identifiers)
                                                        | Parser.Command<ICommand, Sort>("sort", "s")
                                                                 .Nonamed(x => x.Identifiers)
                                                        | Parser.Default<ICommand, Help>("help", "h")
                                                                 .Nonamed(x => x.CommandName);
        static void Main(string[] args)
        {
            //var command = parser.Parse(args);
            //try
            //{
            //    command.Run();
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.Error.WriteLine(e.Message);
            //}
            //catch (ArgumentException e)
            //{
            //    Console.Error.WriteLine(e.Message);
            //}

            var TarotDeck = new Deck(
                "Таро",
                new List<Card>
                {
                        new Card("7 трефы", 9),
                        new Card("2 червы", 2),
                        new Card("3 пики", 5),
                        new Card("5 бубны", 7),
                        new Card("8 трефы", 12),
                        new Card("валет пики", 13),
                        new Card("дама трефы", 14),
                        new Card("король бубны", 20),
                        new Card("Шут красный", 54),
                        new Card("Шут черный", 55)
                });
            var UnoDeck = new Deck(
                "Уно",
                new List<Card>
                {
                        new Card("5 желтая", 25),
                        new Card("2 синяя", 4),
                        new Card("+4 бесцветный", 39),
                        new Card("разворот красный", 41),
                        new Card("разворот синий", 42),
                        new Card("+4 синий", 40),
                        new Card("любое действие", 50),
                });

            var deckRepository = new StorageDeckRepository();

            deckRepository.Create(TarotDeck);
            deckRepository.Create(UnoDeck);
        }
    }
}
