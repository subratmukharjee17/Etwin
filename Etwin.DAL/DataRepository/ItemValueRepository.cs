using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ItemValueRepository : Repository<ItemValue>, IItemValueRepository
    {
        private readonly ETwinContext _db;

        public ItemValueRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemValue itemValue)
        {
            var objFromDb = this._db.ItemValues.FirstOrDefault(s => s.IdItemValues == itemValue.IdItemValues);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemValue);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
