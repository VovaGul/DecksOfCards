using System;
using System.Collections.Generic;
using System.Linq;

namespace DecksOfCards
{
    public class Help : ICommand
    {
        public IReadOnlyList<string> CommandName { get; set; }

        public void Run()
        {
            if (CommandName.Count > 1)
            {
                Console.WriteLine(
                    "команда введена не правильно. " +
                    "чтобы увидеть помощь по программе введите help");
                return;
            }
            if (CommandName.Count == 1)
            {
                var command = CommandName.First();
                switch (command)
                {
                    case "get":
                        GetHelp();
                        break;
                    case "getall":
                        GetAllHelp();
                        break;
                    case "mix":
                        MixHelp();
                        break;
                    case "sort":
                        SortHelp();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            ProgramHelp();
        }

        private void ProgramHelp()
        {
            Console.WriteLine("Описание: Программа для рабаты с колодами");
            Console.WriteLine();
            Console.WriteLine("Использование: DecksOfCards.exe [команда]");
            Console.WriteLine("Для получения сведений об определенной команде введите help <имя команды>");
            Console.WriteLine();
            Console.WriteLine("Команды:");
            Console.WriteLine("  help   | h    помощь по программе");
            Console.WriteLine("  get    | g    показать определенные колды");
            Console.WriteLine("  getall | gl   паказать все колоды");
            Console.WriteLine("  mix    | m    перемешать определенные колоды");
            Console.WriteLine("  sort   | s    отсортировать определенные колоды");
        }

        private void GetHelp()
        {
            Console.WriteLine("Использование: DecksOfCards.exe get <id_колоды1> <id_колоды2> ... <id_колодыN>");
            Console.WriteLine("");
            Console.WriteLine("Пареметры:");
            Console.WriteLine(" id_колоды   id колоды, информацию о которой необходимо показать");
        }

        private void GetAllHelp()
        {
            Console.WriteLine("Использование: DecksOfCards.exe getall");
        }

        private void MixHelp()
        {
            Console.WriteLine("Использование: DecksOfCards.exe mix <id_колоды1> <id_колоды2> ... <id_колодыN>");
            Console.WriteLine("");
            Console.WriteLine("Пареметры:");
            Console.WriteLine(" id_колоды   id колоды, которую нужно перемешать");
        }

        private void SortHelp()
        {
            Console.WriteLine("Использование: DecksOfCards.exe sort <id_колоды1> <id_колоды2> ... <id_колодыN>");
            Console.WriteLine("");
            Console.WriteLine("Пареметры:");
            Console.WriteLine(" id_колоды   id колоды, которую нужно отсортировать");
        }
    }
}
