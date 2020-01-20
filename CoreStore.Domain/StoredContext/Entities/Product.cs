using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Entities
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string QuantityOnHand { get; set; }
    }

}
