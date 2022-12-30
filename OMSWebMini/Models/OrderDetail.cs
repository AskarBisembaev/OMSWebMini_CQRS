using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace OMSWebMini.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public short Quantity { get; set; }
        //public float Discount { get; set; }


        [JsonIgnore]
        public virtual Order Order { get; set; }
        //[JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
