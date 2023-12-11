using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class DepartmentsRepository : Repository<Department>, IDepartmentsRepository
    {
        private readonly GlobalDbContext _db;

        public DepartmentsRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Department departments)
        {
            var objFromDb = this._db.Departments.FirstOrDefault(s => s.IdDepartment == departments.IdDepartment);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(departments);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
