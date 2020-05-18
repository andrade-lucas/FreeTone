using FluentValidator.Validation;
using Tone.Domain.Utils;
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

            if (FirstName == null)
                FirstName = string.Empty;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 2, "FirstName", string.Format(MessagesUtil.MinLength, "Nome", "2"))
                .HasMaxLen(FirstName, 40, "FirstName", string.Format(MessagesUtil.MaxLength, "Nome", 40))
            );
        }
    }
}
