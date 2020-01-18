using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext
{
    public class Delivery
    {
        public DateTime CreateDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
