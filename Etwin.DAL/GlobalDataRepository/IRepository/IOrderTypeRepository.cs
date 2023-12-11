using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOrderTypeRepository : IRepository<OrderType>
    {
        void Update(OrderType orderType);
    }
}
