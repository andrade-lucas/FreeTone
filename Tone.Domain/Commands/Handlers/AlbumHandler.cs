using FluentValidator;
using Tone.Domain.Commands.Inputs.Albums;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class AlbumHandler : Notifiable, ICommandHandler<CreateAlbumCommand>,
    ICommandHandler<EditAlbumCommand>, ICommandHandler<DeleteAlbumCommand>
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
            Gender gender = _genderRepository.GetById(command.GenderId);
            Category category = _categoryRepository.GetById(command.CategoryId);
            
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(EditAlbumCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(DeleteAlbumCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}