using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartPanesRepository : Repository<ChartPane>, IChartPanesRepository
    {
        private readonly ETwinContext _db;

        public ChartPanesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartPane chartPane)
        {
            var objFromDb = this._db.ChartPanes.FirstOrDefault(s => s.Id == chartPane.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartPane);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
