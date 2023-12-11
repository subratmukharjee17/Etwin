using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class RibbonPageGroupsRepository : Repository<RibbonsPageGroup>, IRibbonPageGroupsRepository
    {
        private readonly ETwinContext _db;

        public RibbonPageGroupsRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(RibbonsPageGroup ribbonPageGroup)
        {
            var objFromDb = this._db.RibbonsPageGroups.FirstOrDefault(s => s.Id == ribbonPageGroup.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(ribbonPageGroup);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
