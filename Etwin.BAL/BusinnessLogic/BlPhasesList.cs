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
    public class BlPhasesList : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlPhasesList(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public IList<PhasesList> GetPhasePerIdProcessList(int idProcessList)
        {
            IList<PhasesList> lstPhase = new List<PhasesList>();
            try
            {
                Expression<Func<PhasesList, bool>> expr = e => e.IdProcessList == idProcessList;

                lstPhase = this.unitOfWork.PhasesList.GetAll(expr, null, "IdProcessListNavigation").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstPhase;
        }

        public void AddPhaseslist(PhasesList pl)
        {
            try
            {
                this.unitOfWork.PhasesList.Add(pl);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public bool ExistPhaseList(PhasesList phasesList)
        {
            bool exist = false;
            PhasesList pl = new PhasesList();

            try
            {
                Expression<Func<PhasesList, bool>> expr = e => e.IdPhaseList == phasesList.IdPhaseList;

                pl = this.unitOfWork.PhasesList.GetFirstOrDefault(expr);
                if (pl != null)
                {
                    exist = true;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return exist;
        }

        public void DeletePhasesList(PhasesList phasesList)
        {
            try
            {
                this.unitOfWork.PhasesList.Remove(phasesList);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public decimal GetEstimatedOperatorTime(int idProcessList, int idPhase)
        {
            decimal time = 0;
            PhasesList pl = new PhasesList();
            try
            {
                Expression<Func<PhasesList, bool>> expr = e => e.IdPhaseCompany == idPhase && e.IdProcessList == idProcessList;

                pl = this.unitOfWork.PhasesList.GetFirstOrDefault(expr);
                if (pl != null)
                {
                    if (pl.EstimatedOperatorTime != null)
                        time = (decimal)pl.EstimatedOperatorTime;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return time;
        }

        public IList<PhasesList> GetAllPhasesList()
        {
            IList<PhasesList> phasesList = new List<PhasesList>();
            try
            {
                phasesList = this.unitOfWork.PhasesList.GetAll().ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return phasesList;
        }
        public IList<PhasesList> GetPhaseListByProcessesList(int idProcessList)
        {
            IList < PhasesList > pl = new List<PhasesList >();
            try
            {
                Expression<Func<PhasesList, bool>> expr = e => e.IdProcessList == idProcessList;

                pl = this.unitOfWork.PhasesList.GetAll(expr).ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return pl;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
