using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
