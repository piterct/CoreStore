using CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs;
using CoreStore.Domain.StoredContext.Commands.CustomerComands.Outputs;
using CoreStore.Domain.StoredContext.Entities;
using CoreStore.Domain.StoredContext.Queries;
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
            ValidateFieds(command);
            if (IsValid)
            {

                // Verificar se o CPF já existe na base
                if (_repository.CheckDocument(command.Document))
                    AddNotification("Document", "Este CPF já está em uso");

                //Verificar se o E-mail já existe na base
                if (_repository.CheckEmail(command.Email))
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
                {
                    return new CommandResult(false,
                        "Por favor, corriga os campos abaixo",
                        Notifications);
                }

                else
                {
                    // Persistir o cliente
                    _repository.Save(customer);

                    // Enviar um E-mail de boas vindas
                    //  _emailService.Send(email.Address, "hello@developer.com", "Bem vindo", "Seja Bem vindo ao Core Store!");

                    //Retornar o resultado para tela
                    return new CommandResult(true, "Bem vindo ao Core Store", new
                    {
                        Id = customer.Id,
                        Name = name.ToString(),
                        Email = email.ToString(),
                        BoasVindas = string.Format("{0}, Seja Bem vindo ao Core Store!", customer.Name)
                    }); ;
                }
            }
            else
            {
                return new CommandResult(false,
                        "Por favor, corriga os campos abaixo",
                        Notifications);
            }
        }

        private void ValidateFieds(CreateCustomerCommand command)
        {
            if (string.IsNullOrEmpty(command.FirstName))
                AddNotification("FirstName", "Preencha o parâmetro FirstName");
            if (string.IsNullOrEmpty(command.LastName))
                AddNotification("LastName", "Preencha o parâmetro LastName");
            if (string.IsNullOrEmpty(command.Document))
                AddNotification("Document", "Preencha o parâmetro Document");
            if (string.IsNullOrEmpty(command.Email))
                AddNotification("Email", "Preencha o parâmetro Email");
            if (string.IsNullOrEmpty(command.Phone))
                AddNotification("Phone", "Preencha o parâmetro Phone");

        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            try
            {
                return _repository.Get(document);
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
