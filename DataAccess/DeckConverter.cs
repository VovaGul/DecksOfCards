using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DecksOfCards.UserInterface.Commands
{
    public class DeckConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Deck));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var name = (string)jo["name"];
            var jCards = (JArray)jo["Cards"];
            var cards = new List<Card>();
            foreach (var jCard in jCards)
            {
                var card = JsonConvert.DeserializeObject<Card>(jCard.ToString());
                cards.Add(card);
            }

            Deck deck = new Deck(name, cards);

            return deck;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
