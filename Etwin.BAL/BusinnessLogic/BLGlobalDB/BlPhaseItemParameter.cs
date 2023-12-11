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
    public class BlPhaseItemParameter : IDisposable
    {
        #region VARS
        IUnitOfWork unitOfWork = null;
        private readonly GlobalDbContext _db;
        #endregion

        #region CONSTRUCTOR
        public BlPhaseItemParameter()
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
        public IList<PhasesItemParameter> GetPhaseItemParameter(int? idPhaseCompany = null)
        {
            IList<PhasesItemParameter> lstPip = new List<PhasesItemParameter>();
            try
            {
                //GET ID PHASE BY ID PHASE COMPANY
                Expression<Func<PhasesItemParameter, bool>> expr = null;
                if (idPhaseCompany != null)
                {
                    expr = e => e.IdPhase == idPhaseCompany;
                }
                lstPip = this.unitOfWork.PhasesItemParameters.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPip;
        }
        #endregion
    }
}
