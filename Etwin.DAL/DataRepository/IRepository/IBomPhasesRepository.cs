using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IBomPhasesRepository : IRepository<BomPhase>
    {
        void Update(BomPhase bomPhase);
    }
}
