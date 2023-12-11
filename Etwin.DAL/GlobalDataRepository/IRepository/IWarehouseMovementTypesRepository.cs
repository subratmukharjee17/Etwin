using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWarehouseMovementTypesRepository : IRepository<WarehouseMovementType>
    {
        void Update(WarehouseMovementType warehouseMovementType);
    }
}
