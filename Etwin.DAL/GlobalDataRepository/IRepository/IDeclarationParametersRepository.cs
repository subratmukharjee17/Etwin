using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IDeclarationParametersRepository : IRepository<DeclarationParameter>
    {
        void Update(DeclarationParameter declarationParameter);
    }
}
