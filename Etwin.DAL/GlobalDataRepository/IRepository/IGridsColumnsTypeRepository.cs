using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IGridsColumnsTypeRepository : IRepository<GridsColumnsType>
    {
        void Update(GridsColumnsType gridsColumnsType);
    }
}
