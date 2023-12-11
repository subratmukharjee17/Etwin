using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWarehouseProvenancesRepository : IRepository<WarehouseProvenance>
    {
        void Update(WarehouseProvenance warehouseProvenance);
    }
}
