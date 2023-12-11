using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialSubCategoriesRepository : IRepository<MaterialSubCategory>
    {
        void Update(MaterialSubCategory materialSubCategory);
    }
}
