using System;
using System.Collections.Generic;
using System.Text;

namespace DecksOfCards
{
    public interface IStorage
    {
        List<Deck> Read();
        void Write(List<Deck> decks);
    }
}
