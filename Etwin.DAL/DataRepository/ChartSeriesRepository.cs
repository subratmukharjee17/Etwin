using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartSeriesRepository : Repository<ChartSeries>, IChartSeriesRepository
    {
        private readonly ETwinContext _db;

        public ChartSeriesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartSeries chartSeries)
        {
            var objFromDb = this._db.ChartSeries.FirstOrDefault(s => s.Id == chartSeries.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartSeries);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
