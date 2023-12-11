using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IDocumentArchiveRepository : IRepository<DocumentArchive>
    {
        void Update(DocumentArchive documentArchive);
    }
}
