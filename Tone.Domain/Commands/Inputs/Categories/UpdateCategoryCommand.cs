using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Categories
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}