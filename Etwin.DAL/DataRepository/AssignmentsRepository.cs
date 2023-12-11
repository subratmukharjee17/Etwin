using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class AssignmentsRepository : Repository<Assignment>, IAssignmentsRepository
    {
        private readonly ETwinContext _db;

        public AssignmentsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Assignment assignment)
        {
            var objFromDb = this._db.Assignments.FirstOrDefault(s => s.Id == assignment.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(assignment);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
