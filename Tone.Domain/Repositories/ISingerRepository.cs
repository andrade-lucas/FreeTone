using Tone.Domain.Entities;

namespace Tone.Domain.Repositories
{
    public interface ISingerRepository
    {
        bool Create(Singer singer);
    }
}