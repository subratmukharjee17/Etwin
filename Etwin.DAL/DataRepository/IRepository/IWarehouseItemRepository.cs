using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IWarehouseItemRepository : IRepository<WarehouseItem>
    {
        void Update(WarehouseItem wareHouseItem);
    }
}
