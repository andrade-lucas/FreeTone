using System;
using System.Text;
using Tone.Shared.ValueObject;
using System.Security.Cryptography;
using Tone.Domain.Utils;

namespace Tone.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            Value = this.Cryptograph(value);

            if (Value.Length < 4)
                AddNotification("Password", string.Format(MessagesUtil.MinLength, "Senha", 4));
        }

        private string Cryptograph(string value)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}