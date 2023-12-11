using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IGeneralSettingsRepository : IRepository<GeneralSetting>
    {
        void Update(GeneralSetting generalSettings);
    }
}
