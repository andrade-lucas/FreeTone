using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Genders
{
    public class CreateGenderCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}