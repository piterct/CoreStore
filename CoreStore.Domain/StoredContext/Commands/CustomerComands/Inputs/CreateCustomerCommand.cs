using CoreStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public CreateCustomerCommand()
        {
            Id = Guid.NewGuid();
            DateRegister = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateRegister { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                       .HasMinLen(FirstName, 3, "Firstname", "O nome deve conter pelo menos 3 caractereces")
                       .HasMaxLen(FirstName, 40, "Firstname", "O nome deve conter no máximo 40 caractereces")
                       .HasMinLen(LastName, 3, "LastName", "O nome deve conter pelo menos 3 caractereces")
                       .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 40 caractereces")
                       .IsEmail(Email, "Email", "O E-mail é inválido")
                       .HasLen(Document, 11, "Document", "CPF inválido"));

            return IsValid;
        }
    }

    // Se o usuário existe no banco (Email)
    // Se o usuário existe no banco (CPF)


}
