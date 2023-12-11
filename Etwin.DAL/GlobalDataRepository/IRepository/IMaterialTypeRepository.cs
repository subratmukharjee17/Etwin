using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialTypeRepository : IRepository<MaterialType>
    {
        void Update(MaterialType materialType);
    }
}
