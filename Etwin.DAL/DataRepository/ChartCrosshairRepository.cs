using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartCrosshairRepository : Repository<ChartCrosshair>, IChartCrosshairRepository
    {
        private readonly ETwinContext _db;

        public ChartCrosshairRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartCrosshair crossHairChart)
        {
            var objFromDb = this._db.ChartCrosshairs.FirstOrDefault(s => s.Id == crossHairChart.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(crossHairChart);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
