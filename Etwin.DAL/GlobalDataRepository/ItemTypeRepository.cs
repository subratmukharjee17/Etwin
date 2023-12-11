using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ItemTypeRepository : Repository<ItemType>, IItemTypeRepository
    {
        private readonly GlobalDbContext _db;

        public ItemTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemType itemType)
        {
            var objFromDb = this._db.ItemTypes.FirstOrDefault(s => s.Id == itemType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
