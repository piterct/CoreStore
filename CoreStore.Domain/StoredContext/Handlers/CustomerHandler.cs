using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs;
using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.ValueObjects;
using CoreStore.Shared.Commands;
using FluentValidator;
using System;

namespace CoreStore.Domain.StoredContext.Handlers
{
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAdressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base

            //Verificar se o E-mail já existe na base

            // Criar o Vos

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            // Persistir o cliente

            // Enviar um E-mail de boas vindas

            //Retornar o resultado para tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
