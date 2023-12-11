using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OperatorActiveStatesRepository : Repository<OperatorActiveState>, IOperatorActiveStatesRepository
    {
        private readonly GlobalDbContext _db;

        public OperatorActiveStatesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorActiveState operatorActiveState)
        {
            var objFromDb = this._db.OperatorActiveStates.FirstOrDefault(s => s.IdOperatorActiveState == operatorActiveState.IdOperatorActiveState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorActiveState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
