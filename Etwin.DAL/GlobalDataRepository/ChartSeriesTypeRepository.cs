using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class ChartSeriesTypeRepository : Repository<ChartSeriesType>, IChartSeriesTypeRepository
    {
        private readonly GlobalDbContext _db;

        public ChartSeriesTypeRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartSeriesType chartSeriesType)
        {
            var objFromDb = this._db.ChartSeriesTypes.FirstOrDefault(s => s.Id == chartSeriesType.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(chartSeriesType);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
