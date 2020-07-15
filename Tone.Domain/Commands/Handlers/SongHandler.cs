using FluentValidator;
using Tone.Domain.Commands.Inputs.Songs;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Domain.Utils;
using Tone.Domain.ValueObjects;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class SongHandler : Notifiable, ICommandHandler<CreateSongCommand>,
    ICommandHandler<UpdateSongCommand>, ICommandHandler<DeleteSongCommand>
    {
        private readonly ISongRepository _repository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISingerRepository _singerRepository;

        public SongHandler(ISongRepository repository, IAlbumRepository albumRepository, ISingerRepository singerRepository)
        {
            this._repository = repository;
            this._albumRepository = albumRepository;
            this._singerRepository = singerRepository;
        }

        public ICommandResult Handle(CreateSongCommand command)
        {
            var singerQuery = _singerRepository.GetById(command.SingerId);
            var albumQuery = _albumRepository.GetById(command.AlbumId);
            Name singerName = new Name(singerQuery.FirstName, singerQuery.LastName);

            Singer singer = new Singer(singerQuery.Id, singerName, singerQuery.Nationality, singerQuery.About, singerQuery.Image);
            Album album = new Album(albumQuery.Id, albumQuery.Title, null, null, albumQuery.Image);
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
            var singerQuery = _singerRepository.GetById(command.SingerId);
            var albumQuery = _albumRepository.GetById(command.AlbumId);
            Name singerName = new Name(singerQuery.FirstName, singerQuery.LastName);
            
            Singer singer = new Singer(singerQuery.Id, singerName, singerQuery.Nationality, singerQuery.About, singerQuery.Image);
            Album album = new Album(albumQuery.Id, albumQuery.Title, null, null, albumQuery.Image);
            Song song = new Song(command.Id, command.Title, singer, album, command.Url, command.PublishedDate);

            AddNotifications(song.Notifications);

            if (Invalid)
                return new CommandResult(false, MessagesUtil.FormFail, Notifications);

            bool result = _repository.Update(song);

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