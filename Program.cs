using Binateq.CommandLine;
using DecksOfCards.UserInterface.Commands;
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
                                                        | Parser.Command<ICommand, AddDecks>("add", "a")
                                                                 .Nonamed(x => x.Paths)
                                                        | Parser.Command<ICommand, Mix>("mix", "m")
                                                                 .Nonamed(x => x.Identifiers)
                                                        | Parser.Command<ICommand, Sort>("sort", "s")
                                                                 .Nonamed(x => x.Identifiers)
                                                        | Parser.Default<ICommand, Help>("help", "h")
                                                                 .Nonamed(x => x.CommandName);
        static void Main(string[] args)
        {
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
        }
    }
}
