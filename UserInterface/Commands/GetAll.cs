using System;
using System.Linq;

namespace DecksOfCards
{
    public class GetAll : ICommand
    {
        public void Run()
        {
            var decksStrings = new StorageDeckRepository()
                .GetAll()
                .Select(deck => deck.ToString());
            Console.WriteLine(string.Join("\r\n", decksStrings));
        }
    }
}
