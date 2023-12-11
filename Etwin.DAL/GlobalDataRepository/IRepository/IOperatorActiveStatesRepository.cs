using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOperatorActiveStatesRepository : IRepository<OperatorActiveState>
    {
        void Update(OperatorActiveState operatorActiveState);
    }
}
