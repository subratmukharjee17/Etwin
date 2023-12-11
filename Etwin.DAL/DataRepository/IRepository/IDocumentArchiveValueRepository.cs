using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IDocumentArchiveValueRepository : IRepository<DocumentArchiveValue>
    {
        void Update(DocumentArchiveValue documentArchiveValue);
    }
}
