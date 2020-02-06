

using FluentValidator;
using FluentValidator.Validation;

namespace CoreStore.Domain.StoredContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "Firstname", "O nome deve conter pelo menos 3 caractereces")
                    .HasMaxLen(FirstName, 40, "Firstname", "O nome deve conter no máximo 40 caractereces")
                    .HasMinLen(LastName, 3, "LastName", "O nome deve conter pelo menos 3 caractereces")
                    .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 40 caractereces"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName}  {LastName}";
        }
    }
}
