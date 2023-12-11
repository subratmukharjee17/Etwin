using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlPhaseConstraints : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlPhaseConstraints(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public IList<PhasesConstraint> GetPhaseConstraint(int idPhase)
        {
            IList<PhasesConstraint> lstPhase = new List<PhasesConstraint>();
            try
            {
                Expression<Func<PhasesConstraint, bool>> expr = e => e.IdPhaseCompany == idPhase;

                lstPhase = this.unitOfWork.PhasesConstraints.GetAll(expr, null, null).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstPhase;
        }

        public IList<ConstraintCondition> GetPhasesConditions(int idPhaseConstraint)
        {
            IList<ConstraintCondition> lstConditions = new List<ConstraintCondition>();
            try
            {
                Expression<Func<ConstraintCondition, bool>> expr = e => e.IdPhaseConstraint == idPhaseConstraint;

                lstConditions = this.unitOfWork.ConstraintConditions.GetAll(expr, null, null).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstConditions;
        }

        //public PhasesOutputAction GetOutputActions(int idPhaseCondition)
        //{
        //    PhasesOutputAction actions = new PhasesOutputAction();
        //    try
        //    {
        //        Expression<Func<PhasesOutputAction, bool>> expr = e => e.IdPhaseCondition == idPhaseCondition;
        //        actions = this.unitOfWork.PhasesOutputActions.GetFirstOrDefault(expr, "IdGenericActionTypeNavigation");
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return actions;
        //}


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
