﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
}
