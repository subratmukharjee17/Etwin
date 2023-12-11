using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class GanttRepository : Repository<Gantt>, IGanttRepository
    {
        private readonly ETwinContext _db;

        public GanttRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Gantt gantt)
        {
            var objFromDb = this._db.Gantts.FirstOrDefault(s => s.Id == gantt.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(gantt);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
