using FluentValidator;
using Tone.Domain.Commands.Inputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Domain.Services;
using Tone.Domain.ValueObjects;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;

        public UserHandler(IUserRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var user = new User(name, email, command.Password, command.Birthday, address, command.Image);

            throw new System.NotImplementedException();
        }
    }
}