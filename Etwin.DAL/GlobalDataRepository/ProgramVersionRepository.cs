using Etwin.DAL.DataRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System.Linq;

namespace Etwin.DAL.GlobalDataRepository
{
    public class ProgramVersionRepository : Repository<ProgramVersion>, IProgramVersionRepository
    {
        private readonly GlobalDbContext _db;

        public ProgramVersionRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProgramVersion programVersion)
        {
            var objFromDb = _db.ProgramVersions.FirstOrDefault(s => s.Id == programVersion.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(programVersion);
                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
