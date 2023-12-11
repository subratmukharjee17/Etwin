using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ChartConstantLineRepository : Repository<ChartConstantLine>, IChartConstantLineRepository
    {
        private readonly ETwinContext _db;

        public ChartConstantLineRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ChartConstantLine constantLine)
        {
            var objFromDb = this._db.ChartConstantLines.FirstOrDefault(s => s.IdConstantLine == constantLine.IdConstantLine);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(constantLine);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
