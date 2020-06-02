using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Categories
{
    public class CreateCategoryCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}