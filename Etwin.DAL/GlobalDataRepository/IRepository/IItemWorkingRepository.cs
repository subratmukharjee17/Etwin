using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IItemWorkingRepository : IRepository<ItemWorking>
    {
        void Update(ItemWorking itemWorking);
    }
}
