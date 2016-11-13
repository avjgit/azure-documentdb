using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace lunch.Models
{
    public class Dish
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Display(Name = "Nosaukums")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}