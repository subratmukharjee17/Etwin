using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RibbonPageGroupButtonsRepository : Repository<RibbonsPageGroupButton>, IRibbonPageGroupButtonsRepository
    {
        private readonly ETwinContext _db;

        public RibbonPageGroupButtonsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(RibbonsPageGroupButton ribbonPageGroupButton)
        {
            var objFromDb = this._db.RibbonsPageGroupButtons.FirstOrDefault(s => s.Id == ribbonPageGroupButton.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(ribbonPageGroupButton);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
