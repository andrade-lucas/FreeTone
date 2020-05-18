using FluentValidator.Validation;
using Tone.Shared.ValueObject;

namespace Tone.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 2, "FirstName", "O campo deve ter pelo menos 2 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O campo deve ter no máximo 40 caracteres")
            );
        }
    }
}
