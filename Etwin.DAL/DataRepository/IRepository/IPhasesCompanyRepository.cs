using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IPhasesCompanyRepository : IRepository<PhasesCompany>
    {
        void Update(PhasesCompany phasesCompany);
    }
}
