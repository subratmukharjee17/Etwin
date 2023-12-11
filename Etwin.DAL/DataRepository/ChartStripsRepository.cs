using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartStripsRepository : Repository<ChartStrip>, IChartStripsRepository
    {
        private readonly ETwinContext _db;

        public ChartStripsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartStrip chartStrip)
        {
            var objFromDb = this._db.ChartStrips.FirstOrDefault(s => s.IdChartStrips == chartStrip.IdChartStrips);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartStrip);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
