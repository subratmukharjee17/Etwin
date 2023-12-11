using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IConstraintTypesRepository : IRepository<ConstraintType>
    {
        void Update(ConstraintType constraintType);
    }
}
