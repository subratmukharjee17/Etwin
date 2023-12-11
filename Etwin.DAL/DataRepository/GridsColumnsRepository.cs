using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class GridsColumnsRepository : Repository<GridsColumn>, IGridsColumnsRepository
    {
        private readonly ETwinContext _db;

        public GridsColumnsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GridsColumn gridsColumn)
        {
            var objFromDb = this._db.GridsColumns.FirstOrDefault(s => s.Id == gridsColumn.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(gridsColumn);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
