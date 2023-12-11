using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IItemGraphicComponentRepository : IRepository<ItemGraphicComponent>
    {
        void Update(ItemGraphicComponent itemGraphicComponent);
    }
}
