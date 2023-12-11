using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IItemShapesRepository : IRepository<ItemShape>
    {
        void Update(ItemShape itemShape);
    }
}
