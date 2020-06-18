using System.Collections.Generic;

namespace DecksOfCards
{
    public interface IRepository
    {
        void Create(Deck deck);
        Deck Read(int id);
        void Update(Deck deck);
        void Delete(int id);
        List<Deck> GetAll();
    }
}
