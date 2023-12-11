using Etwin.Model;
using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IProgramVersionRepository : IRepository<ProgramVersion>
    {
        void Update(ProgramVersion programVersion);
    }
}
