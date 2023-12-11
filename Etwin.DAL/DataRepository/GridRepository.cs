using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class GridRepository : Repository<Grid>, IGridRepository
    {
        private readonly ETwinContext _db;

        public GridRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Grid grid)
        {
            var objFromDb = this._db.Grids.FirstOrDefault(s => s.Id == grid.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(grid);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
