using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartAxisTitleRepository : Repository<ChartAxisTitle>, IChartAxisTitleRepository
    {
        private readonly ETwinContext _db;

        public ChartAxisTitleRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartAxisTitle chartAxisTitle)
        {
            var objFromDb = this._db.ChartAxisTitles.FirstOrDefault(s => s.IdAxisTitle == chartAxisTitle.IdAxisTitle);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartAxisTitle);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
