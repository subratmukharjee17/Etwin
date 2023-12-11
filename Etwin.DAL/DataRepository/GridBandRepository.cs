using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class GridBandRepository : Repository<GridBand>, IGridBandRepository
    {
        private readonly ETwinContext _db;

        public GridBandRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GridBand band)
        {
            var objFromDb = this._db.GridBands.FirstOrDefault(s => s.Id == band.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(band);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
