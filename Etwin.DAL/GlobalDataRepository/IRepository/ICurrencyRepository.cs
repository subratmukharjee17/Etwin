using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        void Update(Currency currency);
    }
}
