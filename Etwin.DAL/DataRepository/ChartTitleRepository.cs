using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartTitleRepository : Repository<ChartTitle>, IChartTitleRepository
    {
        private readonly ETwinContext _db;

        public ChartTitleRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartTitle chartTitle)
        {
            var objFromDb = this._db.ChartTitles.FirstOrDefault(s => s.IdChartTitle == chartTitle.IdChartTitle);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartTitle);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
