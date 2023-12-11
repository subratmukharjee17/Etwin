using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartRepository : Repository<Chart>, IChartRepository
    {
        private readonly ETwinContext _db;

        public ChartRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Chart chart)
        {
            var objFromDb = this._db.Charts.FirstOrDefault(s => s.Id == chart.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chart);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
