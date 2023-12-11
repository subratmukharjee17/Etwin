using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOperatorParametersRepository : IRepository<OperatorParameter>
    {
        void Update(OperatorParameter operatorParameter);
    }
}
