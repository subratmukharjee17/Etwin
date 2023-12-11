using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KcfPlannerRepository : Repository<KcfPlanner>, IKcfPlannerRepository
    {
        private readonly ETwinContext _db;

        public KcfPlannerRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(KcfPlanner kcf)
        {
            var objFromDb = this._db.KcfPlanners.FirstOrDefault(s => s.IdKcf == kcf.IdKcf);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kcf);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
