using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DecksOfCards
{
    public class JSONFileStorage : IStorage
    {
        private readonly string path = @"storage.json";
        private readonly JsonSerializerSettings settings;

        public JSONFileStorage()
        {
            settings = new JsonSerializerSettings();
        }

        public JSONFileStorage(string path, JsonSerializerSettings settings)
        {
            this.path = path;
            this.settings = settings;
        }

        private void CheckFileExistence()
        {
            
            if (!File.Exists(path))
            {
                throw new ArgumentException(
                    $"не существует путь до файла хранилища." +
                    $"создайте файл {Path.GetFullPath(path)}");
            }
        }

        public List<Deck> Read()
        {
            CheckFileExistence();
            var output = File.ReadAllText(path);

            List<Deck> decks;
            try
            {
                decks = JsonConvert.DeserializeObject<List<Deck>>(output, settings);
            }
            catch (JsonSerializationException)
            {
                throw new InvalidOperationException
                    ("Предыдущие данные программы записаны не корректно," +
                    " из-за чего не удалось загрузить их");
            }
            catch (JsonReaderException)
            {
                throw new InvalidOperationException
                    ("Предыдущие данные программы не соответствуют формату JSON" +
                    " из-за чего не удалось загрузить их");
            }

            if (decks == null)
            {
                decks = new List<Deck>();
            }
            return decks;
        }

        public void Write(List<Deck> decks)
        {
            var jsonString = JsonConvert.SerializeObject(decks, Formatting.Indented);
            CheckFileExistence();
            File.WriteAllText(path, jsonString);
        }
    }
}
