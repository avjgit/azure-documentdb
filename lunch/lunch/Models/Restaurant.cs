using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace lunch.Models
{
    public class Restaurant
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Display(Name = "Nosaukums")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        [Display(Name = "Apraksts")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "address")]
        [Display(Name = "Adrese")]
        public string Address { get; set; }

        public bool HasDailyOfferToday => true;
    }
}