using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOperatorStatesRepository : IRepository<OperatorState>
    {
        void Update(OperatorState operatorState);
    }
}
