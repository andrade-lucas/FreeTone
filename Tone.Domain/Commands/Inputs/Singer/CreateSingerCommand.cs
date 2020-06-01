using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Singer
{
    public class CreateSingerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
    }
}