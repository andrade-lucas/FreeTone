using System;
using Tone.Domain.Enums;

namespace Tone.Domain.Queries.Users
{
    public class GetUsersQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EUserStatus Status { get; set; }
        public string Image { get; set; }
    }
}