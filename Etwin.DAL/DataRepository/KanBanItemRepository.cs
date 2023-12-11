﻿using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class KanBanItemRepository : Repository<KanBanItem>, IKanBanItemRepository
    {
        private readonly ETwinContext _db;

        public KanBanItemRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(KanBanItem kanBanItem)
        {
            var objFromDb = this._db.KanBanItems.FirstOrDefault(s => s.Id == kanBanItem.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(kanBanItem);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}