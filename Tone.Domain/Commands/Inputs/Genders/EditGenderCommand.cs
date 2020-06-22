using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Genders
{
    public class EditGenderCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}