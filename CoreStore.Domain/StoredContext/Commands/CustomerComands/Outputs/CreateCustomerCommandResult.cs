using CoreStore.Shared.Commands;
using System;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = Name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
