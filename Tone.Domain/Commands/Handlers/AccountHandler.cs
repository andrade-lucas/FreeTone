using FluentValidator;
using Tone.Domain.Commands.Inputs.Account;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Users;
using Tone.Domain.Repositories;
using Tone.Domain.Services;
using Tone.Domain.Utils;
using Tone.Domain.ValueObjects;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class AccountHandler : Notifiable, ICommandHandler<LoginCommand>, 
    ICommandHandler<CreateAccountCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;

        public AccountHandler(IUserRepository repository, IEmailService emailService)
        {
            this._repository = repository;
            this._emailService = emailService;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            Email email = new Email(command.Email);
            Password password = new Password(command.Password);

            AddNotifications(email.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);

            UserAuthQuery user = _repository.Login(email.Address, password.Value);
            
            if (user == null)
                return new CommandResult(false, MessagesUtil.UserNotFound);

            return new CommandResult(true, MessagesUtil.Welcome, data: user); 
        }

        public ICommandResult Handle(CreateAccountCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var password = new Password(command.Password);
            var user = new User(name, email, password, command.Birthdate, null, command.Image);

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(password.Notifications);
            AddNotifications(user.Notifications);

            bool save = _repository.Create(user);
            if (save)
                _emailService.Send(user.Email.Address, MessagesUtil.Welcome, MessagesUtil.EmailWelcome);

            if (!save)
                return new CommandResult(false, MessagesUtil.CreateError, Notifications);

            return new CommandResult(true, MessagesUtil.CreatedSuccess);
        }
    }
}