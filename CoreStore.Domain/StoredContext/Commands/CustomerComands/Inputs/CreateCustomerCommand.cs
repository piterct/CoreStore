using FluentValidator;
using FluentValidator.Validation;

namespace CoreStore.Domain.StoredContext.Commands.CustomerComands.Inputs
{
    public class CreateCustomerCommand : Notifiable
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                       .HasMinLen(FirstName, 3, "Firstname", "O nome deve conter pelo menos 3 caractereces")
                       .HasMaxLen(FirstName, 40, "Firstname", "O nome deve conter no máximo 40 caractereces")
                       .HasMinLen(LastName, 3, "LastName", "O nome deve conter pelo menos 3 caractereces")
                       .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 40 caractereces")
                       .IsEmail(Email, "Email", "O E-mail é inválido")
                       .HasLen(Document, 11, "Document", "CPF inválido"));

            return Valid();
        }
    }

    // Se o usuário existe no banco (Email)
    // Se o usuário existe no banco (CPF)


}
