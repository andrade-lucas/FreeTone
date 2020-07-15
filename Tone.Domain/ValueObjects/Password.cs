using System.Text;
using Tone.Shared.ValueObject;
using System.Security.Cryptography;
using Tone.Domain.Utils;

namespace Tone.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        private readonly string _key = "3C7B4C66-E645-4A2E-A697-F0BD70A295C3";
        
        public string Value { get; private set; }

        public Password(string value)
        {
            if (value.Length < 4)
                AddNotification("Password", string.Format(MessagesUtil.MinLength, "Senha", 4));
                
            Value = this.Cryptograph(value + _key);
        }

        private string Cryptograph(string value)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}