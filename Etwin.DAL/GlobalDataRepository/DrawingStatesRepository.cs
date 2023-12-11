using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository
{
    public class DrawingStatesRepository : Repository<DrawingState>, IDrawingStatesRepository
    {
        private readonly GlobalDbContext _db;

        public DrawingStatesRepository(GlobalDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(DrawingState drawingState)
        {
            var objFromDb = this._db.DrawingStates.FirstOrDefault(s => s.Id == drawingState.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(drawingState);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
