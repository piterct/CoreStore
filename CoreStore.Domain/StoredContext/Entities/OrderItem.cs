using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Entities
{
    public class OrderItem
    {
        public Product Number { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}
