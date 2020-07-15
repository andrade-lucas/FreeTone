using FluentValidator;
using Tone.Domain.Commands.Inputs.Albums;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Domain.Utils;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class AlbumHandler : Notifiable, ICommandHandler<CreateAlbumCommand>,
    ICommandHandler<UpdateAlbumCommand>, ICommandHandler<DeleteAlbumCommand>
    {
        private readonly IAlbumRepository _repository;
        private readonly IGenderRepository _genderRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AlbumHandler(IAlbumRepository repository, IGenderRepository genderRepository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _genderRepository = genderRepository;
            _categoryRepository = categoryRepository;
        }

        public ICommandResult Handle(CreateAlbumCommand command)
        {
            var categoryQuery = _categoryRepository.GetById(command.CategoryId);
            var genderQuery = _genderRepository.GetById(command.GenderId);
            
            Gender gender = new Gender(genderQuery.Id, genderQuery.Title, genderQuery.Description);
            Category category = new Category(categoryQuery.Id, categoryQuery.Title, categoryQuery.Description);
            Album album = new Album(command.Title, gender, category, command.Image);

            AddNotifications(album.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);

            bool result = _repository.Create(album);
            if (!result)
                return new CommandResult(false, MessagesUtil.CreateError, Notifications);

            return new CommandResult(true, MessagesUtil.CreatedSuccess);
        }

        public ICommandResult Handle(UpdateAlbumCommand command)
        {
            var categoryQuery = _categoryRepository.GetById(command.CategoryId);
            var genderQuery = _genderRepository.GetById(command.GenderId);

            Gender gender = new Gender(genderQuery.Id, genderQuery.Title, genderQuery.Description);
            Category category = new Category(categoryQuery.Id, categoryQuery.Title, categoryQuery.Description);
            Album album = new Album(command.Id, command.Title, gender, category, command.Image);

            AddNotifications(album.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);

            bool result = _repository.Update(album);
            if (!result)
                return new CommandResult(false, MessagesUtil.UpdateError, Notifications);

            return new CommandResult(true, MessagesUtil.CreatedSuccess);
        }

        public ICommandResult Handle(DeleteAlbumCommand command)
        {
            if (command.Id.ToString().Length == 0)
                AddNotification("Id", "Identificador inválido!");

            if (Invalid)
                return new CommandResult(false, string.Format(MessagesUtil.InvalidField, "Identificador"), Notifications);

            bool result = _repository.Delete(command.Id);
            if (!result)
                return new CommandResult(false, MessagesUtil.DeleteError, Notifications);

            return new CommandResult(true, MessagesUtil.DeletedSuccess);
        }
    }
}