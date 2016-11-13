using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace lunch.Models
{
    public class Menu
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstDishes")]
        [Display(Name = "Pirmie ēdieni")]
        public List<Dish> FirstPlates { get; set; }

        [JsonProperty(PropertyName = "mainDishes")]
        [Display(Name = "Pamatēdieni")]
        public List<Dish> MainDishes { get; set; }

        [JsonProperty(PropertyName = "desserts")]
        [Display(Name = "Deserti")]
        public List<Dish> Deserts { get; set; }

        [JsonProperty(PropertyName = "drinks")]
        [Display(Name = "Dzērieni")]
        public List<Dish> Drinks { get; set; }
    }
}