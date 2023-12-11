using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ProcessesListRepository : Repository<ProcessesList>, IProcessesListRepository
    {
        private readonly ETwinContext _db;

        public ProcessesListRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ProcessesList processesList)
        {
            var objFromDb = this._db.ProcessesLists.FirstOrDefault(s => s.IdProcessList == processesList.IdProcessList);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(processesList);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
