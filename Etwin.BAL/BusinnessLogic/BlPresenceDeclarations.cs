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
    public class BlPresenceDeclarations : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlPresenceDeclarations(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<PresenceDeclaration> GetOperatorPresence(string operatorCode)
        {
            IList<PresenceDeclaration> lstPresenceDeclaration = new List<PresenceDeclaration>();
            BindingList<PresenceDeclaration> bindingListPresenceDeclaration = new BindingList<PresenceDeclaration>();
            try
            {
                Expression<Func<PresenceDeclaration, bool>> expr = e => e.OperatorCode == operatorCode;

                lstPresenceDeclaration = this.unitOfWork.PresenceDeclarations.GetAll(expr).ToList();
                bindingListPresenceDeclaration = new BindingList<PresenceDeclaration>(lstPresenceDeclaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListPresenceDeclaration;
        }

        public bool AddDeclaration(PresenceDeclaration declaration)
        {
            bool result = false;
            try
            {
                this.unitOfWork.PresenceDeclarations.Add(declaration);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                clsLog.Error("AddDeclaration - Error: " + ex.ToString());
            }
            return result;
        }



        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
