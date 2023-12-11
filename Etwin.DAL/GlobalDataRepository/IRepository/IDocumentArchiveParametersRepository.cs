using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IDocumentArchiveParametersRepository : IRepository<DocumentArchiveParameter>
    {
        void Update(DocumentArchiveParameter documentArchiveParameter);
    }
}
