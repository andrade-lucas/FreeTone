using System.Collections.Generic;

namespace Tone.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body, IList<string> appends);
    }
}