using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System.Collections.Generic;
using System;
using Etwin.DAL.DataRepository;
using System.Linq;
using System.Threading.Tasks;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlAssignments : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlAssignments(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public int GetAssignmentOrder(string operatore, string ordine, string fase)
        {
            int index = 0;
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                ordine = ordine.Split(".")[0];
                Expression<Func<Assignment, bool>> expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.IdProcessListNavigation.IdOrderRowNavigation.IdOrderParentNavigation.Norder == ordine && e.IdPhaseCompanyNavigation.PhaseCode == fase;
                lstAssignment = this.unitOfWork.Assignments.GetAll(expr, null, "IdProcessListNavigation,IdPhaseNavigation").ToList();
                
                index = lstAssignment[0].Priority;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return index;
        }

        public IList<Assignment> GetNewPriority(string operatore, int newIndex, int oldIndex)
        {
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                Expression<Func<Assignment, bool>> expr = null;
                if (oldIndex > newIndex)
                {
                    expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.Priority >= newIndex && e.Priority <= oldIndex /*&& e.Priorita != oldIndex*/;
                }
                else
                {
                    expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.Priority <= newIndex && e.Priority >= oldIndex;
                }
                lstAssignment = this.unitOfWork.Assignments.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstAssignment;
        }

        public IList<Assignment> GetNewPriorityDifferentGroup(string operatore, int oldIndex)
        {
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                Expression<Func<Assignment, bool>> expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.Priority > oldIndex;

                lstAssignment = this.unitOfWork.Assignments.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstAssignment;
        }

        public Assignment GetNewAssignment(string operatore , string ordine, string fase, int Index)
        {
            Assignment a= new Assignment();

            try
            {
                ordine = ordine.Split(".")[0];
                Expression<Func<Assignment, bool>> expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.IdProcessListNavigation.IdOrderRowNavigation.IdOrderParentNavigation.Norder == ordine && e.IdPhaseCompanyNavigation.PhaseCode == fase && e.Priority == Index;
                a = this.unitOfWork.Assignments.GetFirstOrDefault(expr);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return a;
        }

        public IList<Assignment> GetNewPriorityNewColumn(string operatore, int newIndex, int oldIndex)
        {
            IList<Assignment> lstAssignment = new List<Assignment>();
            try
            {
                Expression<Func<Assignment, bool>> expr = null;
                if (oldIndex <= newIndex)
                {
                    expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.Priority >= newIndex;
                }
                else
                {
                    expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == operatore && e.Priority >= newIndex;
                }
                lstAssignment = this.unitOfWork.Assignments.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstAssignment;
        }

        public string GetCaptionByName(string Name)
        {
            string caption = "";
            IList<Assignment> lstAssignment = new List<Assignment> ();
            try
            {
                Expression<Func<Assignment, bool>> expr = e => e.OperatorCodeAssignedToNavigation.NameSurname == Name;
                lstAssignment = this.unitOfWork.Assignments.GetAll(expr, null, "").ToList();
                caption = lstAssignment[0].OperatorCodeAssignedTo;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return caption;
        }

        public void UpdatePriorita(Assignment a)
        {
            try
            {
                this.unitOfWork.Assignments.Update(a);
            }
            catch (Exception ex)
            {
                clsLog.Error("UpdateBand - Error: " + ex.ToString());
            }
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
