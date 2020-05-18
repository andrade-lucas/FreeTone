using FluentValidator;
using Tone.Domain.Utils;
using Tone.Shared.ValueObject;

namespace Tone.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            var addr = new System.Net.Mail.MailAddress(address);

            if (addr.Address != address)
                AddNotification(new Notification("Email", string.Format(MessagesUtil.InvalidField, "Email")));
        }
    }
}
