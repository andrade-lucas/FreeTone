using System;

namespace Tone.Domain.Queries.Users
{
    public class UserAuthQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}