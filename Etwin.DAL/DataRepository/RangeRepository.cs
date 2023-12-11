using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RangeRepository : Repository<Range>, IRangeRepository
    {
        private readonly ETwinContext _db;

        public RangeRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Range range)
        {
            var objFromDb = this._db.Ranges.FirstOrDefault(s => s.IdRange == range.IdRange);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(range);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
