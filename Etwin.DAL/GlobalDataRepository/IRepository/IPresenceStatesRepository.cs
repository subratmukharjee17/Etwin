using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPresenceStatesRepository : IRepository<PresenceState>
    {
        void Update(PresenceState presenceState);
    }
}
