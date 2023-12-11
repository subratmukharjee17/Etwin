using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhasesItemParametersRepository : IRepository<PhasesItemParameter>
    {
        void Update(PhasesItemParameter phasesItemParameter);
    }
}
