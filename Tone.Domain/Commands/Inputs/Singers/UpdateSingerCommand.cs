using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Singers
{
    public class UpdateSingerCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
    }
}