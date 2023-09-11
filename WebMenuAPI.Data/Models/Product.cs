using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMenuAPI.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [JsonPropertyName("img")]
        public string ImageFilename { get; set; }

        public bool Available { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
