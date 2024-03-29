﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMenuAPI.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
