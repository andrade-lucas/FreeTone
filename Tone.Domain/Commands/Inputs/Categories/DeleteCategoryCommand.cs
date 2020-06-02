using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Categories
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}