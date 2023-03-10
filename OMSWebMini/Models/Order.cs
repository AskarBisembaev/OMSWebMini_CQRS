using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace OMSWebMini.Models
{
    public partial class Order
    {
        public Order()
        {
			OrderDetails = new HashSet<OrderDetail>();
		}

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
		public int? EmployeeId { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		//public int? ShipVia { get; set; }
		//public decimal? Freight { get; set; }
		//public string ShipName { get; set; }
		//public string ShipAddress { get; set; }
		//public string ShipCity { get; set; }
		//public string ShipRegion { get; set; }
		//public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CompletedDate { get; set; }

		[JsonIgnore]

		public virtual Customer Customer { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
