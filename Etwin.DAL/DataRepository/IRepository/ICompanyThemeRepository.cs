using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface ICompanyThemeRepository : IRepository<CompanyTheme>
    {
        void Update(CompanyTheme companyTheme);
    }
}
