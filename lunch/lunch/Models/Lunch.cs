using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace lunch.Models
{
    public class Lunch
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        [Display(Name = "Datums")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "menu")]
        [Display(Name = "Ēdienkarte")]
        public Menu Menu { get; set; }

        [JsonProperty(PropertyName = "restaurant")]
        [Display(Name = "Restorāns")]
        public Restaurant Restaurant { get; set; }

        [JsonProperty(PropertyName = "price")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}