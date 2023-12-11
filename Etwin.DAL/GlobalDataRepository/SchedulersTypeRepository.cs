using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class SchedulersTypeRepository : Repository<SchedulersType>, ISchedulersTypeRepository
    {
        private readonly GlobalDbContext _db;

        public SchedulersTypeRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SchedulersType schedulersType)
        {
            var objFromDb = _db.SchedulersTypes.FirstOrDefault(s => s.Id == schedulersType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(schedulersType);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
