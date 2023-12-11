using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.DAL.GlobalDataRepository.IRepository;

namespace  Etwin.DAL.GlobalDataRepository
{
    public class WorkingModesRepository : Repository<WorkingMode>, IWorkingModesRepository
    {
        private readonly GlobalDbContext _db;

        public WorkingModesRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WorkingMode workingMode)
        {
            var objFromDb = _db.WorkingModes.FirstOrDefault(s => s.IdWorkingMode == workingMode.IdWorkingMode);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(workingMode);

                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
