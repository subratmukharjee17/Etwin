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
    public class BlMacroProcesses : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlMacroProcesses(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<MacroProcess> GetMacroProcess(int idMacroProcess)
        {
            IList<MacroProcess> lstMacroProcess = new List<MacroProcess>();
            BindingList<MacroProcess> bindingListMacroProcess = new BindingList<MacroProcess>();
            try
            {
                Expression<Func<MacroProcess, bool>> expr = e => e.IdMacroProcess == idMacroProcess;

                lstMacroProcess = this.unitOfWork.MacroProcesses.GetAll(expr).ToList();
                bindingListMacroProcess = new BindingList<MacroProcess>(lstMacroProcess);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListMacroProcess;
        }


        public IList<MacroProcess> GetAllMacroProcess(IList<int> lst = null)
        {
            IList<MacroProcess> lstMacroProcess = new List<MacroProcess>();
            try
            {
                if (lst == null)
                {
                    lstMacroProcess = this.unitOfWork.MacroProcesses.GetAll().ToList();
                }
                foreach (int id in lst)
                {
                    Expression<Func<MacroProcess, bool>> expr = e => e.IdMacroProcess == id;
                    lstMacroProcess.Add(this.unitOfWork.MacroProcesses.GetFirstOrDefault(expr, ""));
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstMacroProcess;
        }

        public MacroProcess GetMacroProceeById(int id)
        {
            MacroProcess mp = new MacroProcess();

            try
            {
                Expression<Func<MacroProcess, bool>> expr = e => e.IdMacroProcess == id;
                mp = this.unitOfWork.MacroProcesses.GetFirstOrDefault(expr);
            }
            catch
            (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return mp;
        }

        public MacroProcess GetGenericMacroProcess()
        {
            MacroProcess mp = new MacroProcess();
            try
            {
                Expression<Func<MacroProcess, bool>> expr = e => e.IsGeneric == true;
                mp = this.unitOfWork.MacroProcesses.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return mp = new MacroProcess();
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
