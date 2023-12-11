using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhaseActivitiesRepository : IRepository<PhaseActivity>
    {
        void Update(PhaseActivity phaseActivity);
    }
}
