using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IExchangerTypesRepository : IRepository<ExchangerType>
    {
        void Update(ExchangerType exchangerType);
    }
}
