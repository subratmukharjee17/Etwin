using Etwin.Model.GlobalModels;

namespace  Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IChartSeriesTypeRepository : IRepository<ChartSeriesType>
    {
        void Update(ChartSeriesType chartSeriesType);
    }
}
