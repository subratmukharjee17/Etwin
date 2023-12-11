using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>
    {
        void Update(DocumentType documentType);
    }
}
