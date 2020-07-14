using System.Collections.Generic;
using Tone.Domain.Services;

namespace Tone.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string body, IList<string> appends = null)
        {
            // TODO:
        }
    }
}