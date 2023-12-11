using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IDrawingStatesRepository : IRepository<DrawingState>
    {
        void Update(DrawingState drawingState);
    }
}
