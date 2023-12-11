using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class WarehouseMovementRepository : Repository<WarehouseMovement>, IWarehouseMovementRepository
    {
        private readonly ETwinContext _db;

        public WarehouseMovementRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(WarehouseMovement wareHouseMovement)
        {
            var objFromDb = this._db.WarehouseItems.FirstOrDefault(s => s.Id == wareHouseMovement.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(wareHouseMovement);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
