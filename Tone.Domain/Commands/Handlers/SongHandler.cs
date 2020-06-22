using FluentValidator;
using Tone.Domain.Commands.Inputs.Songs;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Domain.Utils;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class SongHandler : Notifiable, ICommandHandler<CreateSongCommand>,
    ICommandHandler<UpdateSongCommand>, ICommandHandler<DeleteSongCommand>
    {
        private readonly ISongRepository _repository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISingerRepository _singerRepository;

        public ICommandResult Handle(CreateSongCommand command)
        {
            Singer singer = _singerRepository.GetById(command.SingerId);
            Album album = _albumRepository.GetById(command.AlbumId);
            Song song = new Song(command.Title, singer, album, command.Url, command.PublishedDate);

            AddNotifications(song.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);
            
            bool result = _repository.Create(song);

            if (!result)
                return new CommandResult(false, MessagesUtil.CreateError, Notifications);

            return new CommandResult(true, MessagesUtil.CreatedSuccess);
        }

        public ICommandResult Handle(UpdateSongCommand command)
        {
            Singer singer = _singerRepository.GetById(command.SingerId);
            Album album = _albumRepository.GetById(command.AlbumId);
            Song song = new Song(command.Id, command.Title, singer, album, command.Url, command.PublishedDate);

            AddNotifications(song.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);

            bool result = _repository.Create(song);

            if (!result)
                return new CommandResult(false, MessagesUtil.UpdateError, Notifications);

            return new CommandResult(true, MessagesUtil.UpdatedSuccess);
        }

        public ICommandResult Handle(DeleteSongCommand command)
        {
            bool result = _repository.Delete(command.Id);

            if (!result)
                return new CommandResult(false, MessagesUtil.DeleteError);
            
            return new CommandResult(true, MessagesUtil.DeletedSuccess);
        }
    }
}