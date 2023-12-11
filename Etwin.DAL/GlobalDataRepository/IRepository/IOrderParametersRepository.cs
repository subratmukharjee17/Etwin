using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOrderParametersRepository : IRepository<OrderParameter>
    {
        void Update(OrderParameter orderParameter);
    }
}
