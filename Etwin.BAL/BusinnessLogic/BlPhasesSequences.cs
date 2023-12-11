using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlPhasesSequences : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlPhasesSequences(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<PhasesSequence> GetPhasesSequence(int idPhasesSequence)
        {
            IList<PhasesSequence> lstPhasesSequence = new List<PhasesSequence>();
            BindingList<PhasesSequence> bindingListPhasesSequence = new BindingList<PhasesSequence>();
            try
            {
                Expression<Func<PhasesSequence, bool>> expr = e => e.IdPhaseSequence == idPhasesSequence;

                lstPhasesSequence = this.unitOfWork.PhasesSequences.GetAll(expr).ToList();
                bindingListPhasesSequence = new BindingList<PhasesSequence>(lstPhasesSequence);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListPhasesSequence;
        }

        public IList<PhasesSequence> GetPhasesSequenceByPhase(int idPhase)
        {
            IList<PhasesSequence> lstPhasesSequence = new List<PhasesSequence>();
            try
            {
                Expression<Func<PhasesSequence, bool>> expr = e => e.IdPhaseCompany == idPhase;

                lstPhasesSequence = this.unitOfWork.PhasesSequences.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstPhasesSequence;
        }


        public IList<PhasesSequence> GetAllPhasesSequence()
        {
            IList<PhasesSequence> lstPhasesSequence = new List<PhasesSequence>();
            try
            {
                lstPhasesSequence = this.unitOfWork.PhasesSequences.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstPhasesSequence;
        }
        
        public IList<PhasesSequence> GetPhaseSequenceByMacroProcess(IList<int> lstIdMacroProcess)
        {
            IList<PhasesSequence> lstphase = new List<PhasesSequence>();

            try
            {
                foreach(int idMp in lstIdMacroProcess)
                {
                    Expression<Func<PhasesSequence, bool>> expr = e => e.IdMacroProcesses == idMp;

                    lstphase.Add(this.unitOfWork.PhasesSequences.GetFirstOrDefault(expr, "IdMacroProcessesNavigation"));
                }
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstphase;
        }
        
        public IList<int> GetPhasesSequenceByIdProcess(int idMacroProcess)
        {
            IList<int> lstIdPhase = new List<int>();
            try
            {
                IList<PhasesSequence> lstPhase = new List<PhasesSequence>();
                Expression<Func<PhasesSequence, bool>> expr = e => e.IdMacroProcesses == idMacroProcess;

                lstPhase = this.unitOfWork.PhasesSequences.GetAll(expr).ToList();
                foreach (PhasesSequence ps in lstPhase)
                {
                    lstIdPhase.Add((int)ps.IdPhaseCompany);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstIdPhase;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
