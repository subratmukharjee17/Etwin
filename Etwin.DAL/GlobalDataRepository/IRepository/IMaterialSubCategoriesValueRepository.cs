using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialSubCategoriesValueRepository : IRepository<MaterialSubCategoriesValue>
    {
        void Update(MaterialSubCategoriesValue materialSubCategorieValue);
    }
}
