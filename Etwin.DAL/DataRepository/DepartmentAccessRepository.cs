using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class DepartmentAccessRepository : Repository<DepartmentAccess>, IDepartmentAccessRepository
    {
        private readonly ETwinContext _db;

        public DepartmentAccessRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DepartmentAccess departmentAccess)
        {
            var objFromDb = this._db.DepartmentAccesses.FirstOrDefault(s => s.IdDepartmentAccess == departmentAccess.IdDepartmentAccess);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(departmentAccess);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
