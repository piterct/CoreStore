using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs
{
    public class ListCreateCustomersCommand
    {

        public List<CreateCustomerCommand> Customers { get; set; }

    }
}
