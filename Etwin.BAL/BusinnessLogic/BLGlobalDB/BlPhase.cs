using Etwin.DAL.GlobalDataRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Etwin.BAL.BusinnessLogic.BLGlobalDB
{
    public class BlPhase : IDisposable
    {
        #region VARS
        IUnitOfWork unitOfWork = null;
        private readonly GlobalDbContext _db;
        #endregion

        #region CONSTRUCTOR
        public BlPhase()
        {
            this._db = new GlobalDbContext();
            this.unitOfWork = new UnitOfWork(_db);
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region GET PHASE ITEM PARAMETER
        public Phase GetPhase(int idPhase)
        {
            Phase p = new Phase();
            try
            {
                //GET ID PHASE BY ID PHASE COMPANY
                Expression<Func<Phase, bool>> expr = e => e.IdPhase == idPhase;
                
                p = this.unitOfWork.Phases.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return p;
        }
        #endregion
    }
}
