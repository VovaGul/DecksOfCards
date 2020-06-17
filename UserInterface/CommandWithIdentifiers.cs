using System;
using System.Collections.Generic;

namespace DecksOfCards
{
    abstract class CommandWithIdentifiers : ICommand
    {
        public IReadOnlyList<string> Identifiers { get; set; }

        public abstract void Run();

        protected int ParseId(string id)
        {
            int idNumber;
            try
            {
                idNumber = int.Parse(id);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException($"введенное Id={id} не является целым числом");
            }
            return idNumber;
        }

        protected void CheckIdentifiersExistence()
        {
            if (Identifiers.Count == 0)
                throw new InvalidOperationException("Пропущены id колод");
        }
    }
}
