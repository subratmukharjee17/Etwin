using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class TimestepsRepository : Repository<Timestep>, ITimestepsRepository
    {
        private readonly ETwinContext _db;

        public TimestepsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Timestep timestep)
        {
            var objFromDb = this._db.Timesteps.FirstOrDefault(s => s.IdTimestep == timestep.IdTimestep);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(timestep);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
