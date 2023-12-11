using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RangeAreaChartRepository : Repository<RangeAreaChart>, IRangeAreaChartRepository
    {
        private readonly ETwinContext _db;

        public RangeAreaChartRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(RangeAreaChart rangeAreaChart)
        {
            var objFromDb = this._db.RangeAreaCharts.FirstOrDefault(s => s.IdAreaChartRange == rangeAreaChart.IdAreaChartRange);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(rangeAreaChart);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
