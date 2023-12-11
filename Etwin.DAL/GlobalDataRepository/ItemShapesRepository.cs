using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ItemShapesRepository : Repository<ItemShape>, IItemShapesRepository
    {
        private readonly GlobalDbContext _db;

        public ItemShapesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemShape itemShape)
        {
            var objFromDb = this._db.ItemShapes.FirstOrDefault(s => s.Id == itemShape.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemShape);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
