using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IItemTypeRepository : IRepository<ItemType>
    {
        void Update(ItemType itemType);
    }
}
