using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class WarehouseItemRepository : Repository<WarehouseItem>, IWarehouseItemRepository
    {
        private readonly ETwinContext _db;

        public WarehouseItemRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(WarehouseItem wareHouseItem)
        {
            var objFromDb = this._db.WarehouseItems.FirstOrDefault(s => s.Id == wareHouseItem.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(wareHouseItem);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
