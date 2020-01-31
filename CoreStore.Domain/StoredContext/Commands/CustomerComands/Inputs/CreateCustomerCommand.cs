using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs
{
    public class CreateCustomerCommand
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Dcoument { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
