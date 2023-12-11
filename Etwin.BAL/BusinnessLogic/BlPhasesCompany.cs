using System.Linq.Expressions;
using LogDll;
using System.Drawing;
using System;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model;
using Etwin.DAL.DataRepository;

namespace ETwin.BAL
{
    public class BlPhasesCompany : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlPhasesCompany(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        #region GET PHASE COMAPNY BY ID GLOBAL
        public PhasesCompany GetPhaseCompanyByIdGlobal(int id)
        {
            PhasesCompany phasesCompany = new PhasesCompany();
            try
            {
                Expression<Func<PhasesCompany, bool>> expr = e => e.IdPhase == id;
                phasesCompany = this.unitOfWork.PhasesCompany.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return phasesCompany;
        }
        #endregion

        #region GET PHASE COMPANY BY ID (PK)
        public PhasesCompany GetPhaseCompanyById(int id)
        {
            PhasesCompany phasesCompany = new PhasesCompany();
            try
            {
                Expression<Func<PhasesCompany, bool>> expr = e => e.Id == id;
                phasesCompany = this.unitOfWork.PhasesCompany.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return phasesCompany;
        }
        #endregion

        #region GET PHASE BY PHASE CODE
        public PhasesCompany GetPhaseFromCode(string tskCode)
        {

            PhasesCompany Phase = new PhasesCompany();
            try
            {
                Expression<Func<PhasesCompany, bool>> expr = e => e.PhaseCode == tskCode;
                Phase = this.unitOfWork.PhasesCompany.GetFirstOrDefault(expr, "");
            }
            catch (Exception ex)
            {
                Phase = null;
                clsLog.Error("GetPhaseFromCode - Error: " + ex.ToString());
            }

            return Phase;
        }
        #endregion
        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
