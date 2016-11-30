using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class JsonRecipes
    {
        public string id { get; set; }
        public string name { get; set; }
        public int creatorId { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public int calories { get; set; }
        public string preparation { get; set; }
        public List<string> ingredients { get; set; }
        public List<JsonComments> comments { get; set; }
    }

    public class JsonComments
    {
        public int userId { get;set; } 
        public string title { get; set; }
        public string comment { get; set; }
        public Decimal mark { get; set; }
    }
}