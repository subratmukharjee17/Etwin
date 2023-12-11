using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KanBanGroupRepository : Repository<KanBanGroup>, IKanBanGroupRepository
    {
        private readonly ETwinContext _db;

        public KanBanGroupRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(KanBanGroup kanBanGroup)
        {
            var objFromDb = this._db.KanBanGroups.FirstOrDefault(s => s.Id == kanBanGroup.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kanBanGroup);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
