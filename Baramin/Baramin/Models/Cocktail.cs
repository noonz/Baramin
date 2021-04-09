﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Baramin.Models
{
    public partial class Cocktail
    {
        [JsonProperty("drinks")]
        public List<Drink> Drinks { get; set; }
    }

    public partial class Drink
    {
        [JsonProperty("strDrink")]
        public string StrDrink { get; set; }

        [JsonProperty("strDrinkThumb")]
        public Uri StrDrinkThumb { get; set; }

        [JsonProperty("idDrink")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long IdDrink { get; set; }
    }

    public partial class Cocktail
    {
        public static Cocktail FromJson(string json) => JsonConvert.DeserializeObject<Cocktail>(json, Converter.Settings);
    }


    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
