using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IEventStateRepository : IRepository<EventState>
    {
        void Update(EventState eventState);
    }
}
