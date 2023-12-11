using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class PedRepository : Repository<Ped>, IPedRepository
    {
        private readonly GlobalDbContext _db;

        public PedRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Ped ped)
        {
            var objFromDb = this._db.Peds.FirstOrDefault(s => s.IdPed == ped.IdPed);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(ped);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
