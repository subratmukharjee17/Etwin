using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IBomTypeRepository : IRepository<BomType>
    {
        void Update(BomType bomType);
    }
}
