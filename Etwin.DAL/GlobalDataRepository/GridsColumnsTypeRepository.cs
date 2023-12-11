using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class GridsColumnsTypeRepository : Repository<GridsColumnsType>, IGridsColumnsTypeRepository
    {
        private readonly GlobalDbContext _db;

        public GridsColumnsTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GridsColumnsType GridsColumnsType)
        {
            var objFromDb = this._db.GridsColumnsTypes.FirstOrDefault(s => s.Id == GridsColumnsType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(GridsColumnsType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
