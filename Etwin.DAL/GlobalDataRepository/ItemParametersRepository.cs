using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ItemParametersRepository : Repository<ItemParameter>, IItemParametersRepository
    {
        private readonly GlobalDbContext _db;

        public ItemParametersRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ItemParameter itemParameter)
        {
            var objFromDb = this._db.ItemParameters.FirstOrDefault(s => s.IdItemParameter == itemParameter.IdItemParameter);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(itemParameter);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
