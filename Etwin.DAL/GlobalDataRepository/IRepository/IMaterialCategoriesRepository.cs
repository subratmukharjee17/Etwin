using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialCategoriesRepository : IRepository<MaterialCategory>
    {
        void Update(MaterialCategory materialCategory);
    }
}
