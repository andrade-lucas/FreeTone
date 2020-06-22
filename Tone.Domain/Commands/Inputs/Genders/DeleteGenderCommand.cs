using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Genders
{
    public class DeleteGenderCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}