using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace OMSWebMini.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public string Description { get; set; }
        //public byte[] Picture { get; set; }


        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
