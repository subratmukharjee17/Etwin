﻿using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class GridTooltipRepository : Repository<GridTooltip>, IGridTooltipRepository
    {
        private readonly ETwinContext _db;

        public GridTooltipRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(GridTooltip toolTipGrid)
        {
            var objFromDb = this._db.GridTooltips.FirstOrDefault(s => s.Id == toolTipGrid.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(toolTipGrid);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
