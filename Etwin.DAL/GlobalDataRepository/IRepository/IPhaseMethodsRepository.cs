using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhaseMethodsRepository : IRepository<PhaseMethod>
    {
        void Update(PhaseMethod phaseMethod);
    }
}
