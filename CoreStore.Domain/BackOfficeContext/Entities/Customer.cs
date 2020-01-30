using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.BackOfficeContext.Entities
{
    public class Customer
    {
        public IReadOnlyCollection<Product> Produts { get; set; }
        public Name Name { get; set; }
    }
}
