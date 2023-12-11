using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IWarehouseMovementRepository : IRepository<WarehouseMovement>
    {
        void Update(WarehouseMovement wareHouseMovement);
    }
}
