using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
