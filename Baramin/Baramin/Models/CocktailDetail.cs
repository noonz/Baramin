using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Baramin.Models
{
    public partial class DrinkDetail
    {

        [JsonProperty("idDrink")]
        public string IdDrink { get; set; }

        [JsonProperty("strDrink")]
        public string StrDrink { get; set; }

        [JsonProperty("strCategory")]
        public string StrCategory { get; set; }

        [JsonProperty("strAlcoholic")]
        public string StrAlcoholic { get; set; }

        [JsonProperty("strGlass")]
        public string StrGlass { get; set; }

        [JsonProperty("strInstructions")]
        public string StrInstructions { get; set; }

        [JsonProperty("strDrinkThumb")]
        public Uri StrDrinkThumb { get; set; }

        [JsonProperty("strIngredient1")]
        public string StrIngredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string StrIngredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string StrIngredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string StrIngredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string StrIngredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string StrIngredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string StrIngredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string StrIngredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string StrIngredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string StrIngredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string StrIngredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string StrIngredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string StrIngredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string StrIngredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string StrIngredient15 { get; set; }

        [JsonProperty("strMeasure1")]
        public string StrMeasure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string StrMeasure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string StrMeasure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string StrMeasure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string StrMeasure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string StrMeasure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string StrMeasure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string StrMeasure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string StrMeasure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string StrMeasure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string StrMeasure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string StrMeasure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string StrMeasure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string StrMeasure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string StrMeasure15 { get; set; }
    }

    public class CocktailDetail
    {

        [JsonProperty("drinks")]
        public List<DrinkDetail> Drinks { get; set; }
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

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(List<long>);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (List<long>)untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
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
            throw new Exception("fail");
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
}