using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Genders
{
    public class UpdateGenderCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}