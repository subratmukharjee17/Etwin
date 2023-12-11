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
    public class BlProcessesLists : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlProcessesLists(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddProcessList(ProcessesList pl)
        {
            try
            {
                this.unitOfWork.ProcessesList.Add(pl);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        public BindingList<ProcessesList> GetProcessesList(int idProcessesList)
        {
            IList<ProcessesList> lstProcessesList = new List<ProcessesList>();
            BindingList<ProcessesList> bindingListProcessesList = new BindingList<ProcessesList>();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdProcessList == idProcessesList;

                lstProcessesList = this.unitOfWork.ProcessesList.GetAll(expr).ToList();
                bindingListProcessesList = new BindingList<ProcessesList>(lstProcessesList);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListProcessesList;
        }

        public ProcessesList GetProcessesListById(int idProcessesList)
        {
            ProcessesList processesList = new ProcessesList();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdProcessList == idProcessesList;

                processesList = this.unitOfWork.ProcessesList.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return processesList;
        }

        public IList<ProcessesList> GetProcessesListByOrder(int idOrder)
        {
            IList<ProcessesList> processesList = new List<ProcessesList>();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdOrderRow == idOrder;
                processesList = this.unitOfWork.ProcessesList.GetAll(expr).ToList();

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return processesList;
        }

        public IList<ProcessesList> GetAllProcessesListOfYear(int anno)
        {
            IList<ProcessesList> lstProcessesList = new List<ProcessesList>();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.ProcessCode.Contains(anno + "/");
                lstProcessesList = this.unitOfWork.ProcessesList.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstProcessesList;
        }

        public bool ExistPL(int idOrder, int idProcess, int idItem)
        {
            bool exist = false;

            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdOrderRow == idOrder && e.IdMacroProcess == idProcess && e.IdItem == idItem;
                ProcessesList pl = this.unitOfWork.ProcessesList.GetFirstOrDefault(expr);
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

        public ProcessesList ExistPLWithReturn(int idOrder, int idProcess, int idItem)
        {
            ProcessesList pl = new ProcessesList();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdOrderRow == idOrder && e.IdMacroProcess == idProcess && e.IdItem == idItem;
                pl = this.unitOfWork.ProcessesList.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return pl;
        }

        public void UpdateProcessList(ProcessesList pl)
        {
            try
            {
                this.unitOfWork.ProcessesList.Update(pl);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void DeleteProcessList(ProcessesList processesList)
        {
            try
            {

                this.unitOfWork.ProcessesList.Remove(processesList);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public IList<ProcessesList> GetProcessesListByItem(int idItem)
        {
            IList<ProcessesList > list = new List<ProcessesList>();
            try
            {
                Expression<Func<ProcessesList, bool>> expr = e => e.IdItem == idItem;
                list = this.unitOfWork.ProcessesList.GetAll(expr).ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return list;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
