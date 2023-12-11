using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ItemWorkingRepository : Repository<ItemWorking>, IItemWorkingRepository
    {
        private readonly GlobalDbContext _db;

        public ItemWorkingRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemWorking itemWorking)
        {
            var objFromDb = this._db.ItemWorkings.FirstOrDefault(s => s.Id == itemWorking.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemWorking);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
