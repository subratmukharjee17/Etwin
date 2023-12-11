using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class MovementTypesRepository : Repository<MovementType>, IMovementTypesRepository
    {
        private readonly GlobalDbContext _db;

        public MovementTypesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(MovementType movementType)
        {
            var objFromDb = this._db.MovementTypes.FirstOrDefault(s => s.IdMovementType == movementType.IdMovementType);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(movementType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
