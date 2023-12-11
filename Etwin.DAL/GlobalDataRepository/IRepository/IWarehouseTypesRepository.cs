using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWarehouseTypesRepository : IRepository<WarehouseType>
    {
        void Update(WarehouseType warehouseType);
    }
}
