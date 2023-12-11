using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWarehousesRepository : IRepository<Warehouse>
    {
        void Update(Warehouse warehouse);
    }
}
