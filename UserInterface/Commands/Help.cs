using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

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
                    case "g":
                        GetHelp();
                        break;
                    case "getall":
                    case "gl":
                        GetAllHelp();
                        break;
                    case "mix":
                    case "m":
                        MixHelp();
                        break;
                    case "sort":
                    case "s":
                        SortHelp();
                        break;
                    default:
                        Console.WriteLine("такой команды не существует");
                        break;
                }
                return;
            }
            ProgramHelp();
        }

        private void ProgramHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Описание: Программа для рабаты с колодами");
            sb.AppendLine();
            sb.AppendLine("Использование: DecksOfCards.exe [команда]");
            sb.AppendLine("Для получения сведений об определенной команде введите help <имя команды>");
            sb.AppendLine();
            sb.AppendLine("Команды:");
            sb.AppendLine("  help   | h    помощь по программе");
            sb.AppendLine("  get    | g    показать определенные колды");
            sb.AppendLine("  getall | gl   паказать все колоды");
            sb.AppendLine("  mix    | m    перемешать определенные колоды");
            sb.AppendLine("  sort   | s    отсортировать определенные колоды");

            Console.WriteLine(sb.ToString());
        }

        private void GetHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Использование: DecksOfCards.exe get <id_колоды1> <id_колоды2> ... <id_колодыN>");
            sb.AppendLine("");
            sb.AppendLine("Пареметры:");
            sb.AppendLine(" id_колоды   id колоды, информацию о которой необходимо показать");

            Console.WriteLine(sb.ToString());
        }

        private void GetAllHelp()
        {
            Console.WriteLine("Использование: DecksOfCards.exe getall");
        }

        private void MixHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Использование: DecksOfCards.exe mix <id_колоды1> <id_колоды2> ... <id_колодыN>");
            sb.AppendLine("");
            sb.AppendLine("Пареметры:");
            sb.AppendLine(" id_колоды   id колоды, которую нужно перемешать");

            Console.WriteLine(sb.ToString());
        }

        private void SortHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Использование: DecksOfCards.exe sort <id_колоды1> <id_колоды2> ... <id_колодыN>");
            sb.AppendLine("");
            sb.AppendLine("Пареметры:");
            sb.AppendLine(" id_колоды   id колоды, которую нужно отсортировать");

            Console.WriteLine(sb.ToString());
        }
    }
}
