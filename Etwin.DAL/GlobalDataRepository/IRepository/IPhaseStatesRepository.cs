using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhaseStatesRepository : IRepository<PhaseState>
    {
        void Update(PhaseState phaseState);
    }
}
