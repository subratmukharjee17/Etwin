using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        private readonly ETwinContext _db;

        public ItemsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Item item)
        {
            var objFromDb = this._db.Items.FirstOrDefault(s => s.IdItem == item.IdItem);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(item);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
