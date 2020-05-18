using System.Text.RegularExpressions;
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

            if (!IsEmail())
                AddNotification(new Notification("Email", string.Format(MessagesUtil.InvalidField, "Email")));
        }

        private bool IsEmail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Address);

            return match.Success;
        }
    }
}