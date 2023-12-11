using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KanBanBoardRepository : Repository<KanBanBoard>, IKanBanBoardRepository
    {
        private readonly ETwinContext _db;

        public KanBanBoardRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(KanBanBoard kanBanBoard)
        {
            var objFromDb = this._db.KanBanBoards.FirstOrDefault(s => s.Id == kanBanBoard.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kanBanBoard);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
