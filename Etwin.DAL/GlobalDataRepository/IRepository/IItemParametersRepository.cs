using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IItemParametersRepository : IRepository<ItemParameter>
    {
        void Update(ItemParameter itemParameter);
    }
}
