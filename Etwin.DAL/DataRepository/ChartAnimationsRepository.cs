using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartAnimationsRepository : Repository<ChartAnimation>, IChartAnimationsRepository
    {
        private readonly ETwinContext _db;

        public ChartAnimationsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartAnimation chartAnimations)
        {
            var objFromDb = this._db.ChartAnimations.FirstOrDefault(s => s.IdChartAnimation == chartAnimations.IdChartAnimation);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartAnimations);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
