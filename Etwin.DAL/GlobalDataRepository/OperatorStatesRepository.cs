using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class OperatorStatesRepository : Repository<OperatorState>, IOperatorStatesRepository
    {
        private readonly GlobalDbContext _db;

        public OperatorStatesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(OperatorState operatorState)
        {
            var objFromDb = this._db.OperatorStates.FirstOrDefault(s => s.IdOperatorState == operatorState.IdOperatorState);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(operatorState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
