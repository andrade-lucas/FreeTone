using System;
using FluentValidator;
using Tone.Domain.Commands.Inputs.User;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Domain.Services;
using Tone.Domain.ValueObjects;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<UpdateUserCommand>, 
    ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;

        public UserHandler(IUserRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var user = new User(command.Id, name, null, command.Birthdate, address, command.Image);

            AddNotifications(name.Notifications);
            AddNotifications(address.Notifications);
            AddNotifications(user.Notifications);

            if (Invalid)
                return new CommandResult(false, "Falha ao atualizar usuário", Notifications);
            
            var result = _repository.Update(user);

            if (!result)
                return new CommandResult(false, "Falha ao atualizar usuário");

            return new CommandResult(true, "Usuário atualizado com sucesso");
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            bool result = _repository.Delete(command.Id);

            if (!result)
                return new CommandResult(false, "Erro ao deletar usuário! \nPor favor, tente mais tarde.");

            return new CommandResult(true, "Usuário deletado com sucesso!");
        }
    }
}