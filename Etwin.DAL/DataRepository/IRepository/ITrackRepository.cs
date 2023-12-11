using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface ITrackRepository : IRepository<Track>
    {
        void Update(Track track);
    }
}
