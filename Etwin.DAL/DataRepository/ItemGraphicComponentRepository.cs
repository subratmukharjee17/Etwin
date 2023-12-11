using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class ItemGraphicComponentRepository : Repository<ItemGraphicComponent>, IItemGraphicComponentRepository
    {
        private readonly ETwinContext _db;

        public ItemGraphicComponentRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemGraphicComponent itemGraphicComponent)
        {
            var objFromDb = this._db.ItemGraphicComponents.FirstOrDefault(s => s.Id == itemGraphicComponent.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemGraphicComponent);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
