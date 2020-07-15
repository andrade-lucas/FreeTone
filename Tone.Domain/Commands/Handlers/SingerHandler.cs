using Tone.Shared.Commands;
using Tone.Domain.Repositories;
using Tone.Domain.Commands.Inputs.Singers;
using Tone.Domain.ValueObjects;
using Tone.Domain.Entities;
using FluentValidator;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Commands.Inputs.singers;

namespace Tone.Domain.Commands.Handlers
{
    public class SingerHandler : Notifiable, ICommandHandler<CreateSingerCommand>, 
    ICommandHandler<UpdateSingerCommand>, ICommandHandler<DeleteSingerCommand>
    {
        private readonly ISingerRepository _repository;

        public SingerHandler(ISingerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateSingerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var singer = new Singer(name, command.Nationality, command.About, command.Image);

            AddNotifications(name.Notifications);
            AddNotifications(singer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Falha ao cadastrar cantor", Notifications);

            var retorno = _repository.Create(singer);

            if (!retorno)
                return new CommandResult(false, "Falha ao cadastrar Cantor", Notifications);

            return new CommandResult(true, "Cantor Cadastrado com sucesso");
        }

        public ICommandResult Handle(UpdateSingerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var singer = new Singer(command.Id, name, command.Nationality, command.About, command.Image);

            AddNotifications(name.Notifications);
            AddNotifications(singer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Falha ao atualizar cantor", Notifications);

            bool result = _repository.Update(singer);
            
            if (!result)
                return new CommandResult(false, "Falha ao atualizar cantor");

            return new CommandResult(true, "Cantor atualizado com sucesso");
        }

        public ICommandResult Handle(DeleteSingerCommand command)
        {
            bool result = _repository.Delete(command.Id);

            if (!result)
                return new CommandResult(false, "Erro ao deletar cantor");
            
            return new CommandResult(true, "Cantor deletado com sucesso");
        }
    }
}