using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs;
using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Domain.StoredContext.Services;
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

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CustomerDcoument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o E-mail já existe na base
            if (_repository.CustomerDcoument(command.Email))
                AddNotification("Email", "Este Email já está em uso");


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

            if (Invalid)
                return null;

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "hello@developer.com", "Bem vindo", "Seja Bem vindo ao Core Store!");

            //Retornar o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
