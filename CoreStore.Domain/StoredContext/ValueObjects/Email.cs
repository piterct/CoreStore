using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
