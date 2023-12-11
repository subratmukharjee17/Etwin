using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RibbonPagesRepository : Repository<RibbonsPage>, IRibbonPagesRepository
    {
        private readonly ETwinContext _db;

        public RibbonPagesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(RibbonsPage ribbonPage)
        {
            var objFromDb = this._db.RibbonsPages.FirstOrDefault(s => s.Id == ribbonPage.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(ribbonPage);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
