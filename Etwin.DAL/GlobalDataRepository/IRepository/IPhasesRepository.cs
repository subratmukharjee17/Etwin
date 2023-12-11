using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPhasesRepository : IRepository<Phase>
    {
        void Update(Phase phase);
    }
}
