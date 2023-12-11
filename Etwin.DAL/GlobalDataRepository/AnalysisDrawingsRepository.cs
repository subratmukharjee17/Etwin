using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class AnalysisDrawingsRepository : Repository<AnalysisDrawing>, IAnalysisDrawingsRepository
    {
        private readonly GlobalDbContext _db;

        public AnalysisDrawingsRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(AnalysisDrawing analysisDrawing)
        {
            var objFromDb = this._db.AnalysisDrawings.FirstOrDefault(s => s.Id == analysisDrawing.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(analysisDrawing);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
