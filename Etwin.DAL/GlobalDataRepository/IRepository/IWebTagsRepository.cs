using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IWebTagsRepository : IRepository<WebTag>
    {
        void Update(WebTag webTag);
    }
}
