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
    public class BlDeclarationValues : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlDeclarationValues(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.unitOfWork.DeclarationValues.Add(declarationValue);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public BindingList<DeclarationValue> GetDeclarationValue(int idDeclarationValue)
        {
            IList<DeclarationValue> lstDeclarationValue = new List<DeclarationValue>();
            BindingList<DeclarationValue> bindingListDeclarationValue = new BindingList<DeclarationValue>();
            try
            {
                Expression<Func<DeclarationValue, bool>> expr = e => e.IdDeclarationValues == idDeclarationValue;

                lstDeclarationValue = this.unitOfWork.DeclarationValues.GetAll(expr).ToList();
                bindingListDeclarationValue = new BindingList<DeclarationValue>(lstDeclarationValue);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListDeclarationValue;
        }

        public void UpdateDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.unitOfWork.DeclarationValues.Update(declarationValue);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void DeleteDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.unitOfWork.DeclarationValues.Remove(declarationValue);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        
        public bool IsDeclarationTerminate(int idDeclaration)
        {
            bool terminate = false;
            try
            {
                Expression<Func<DeclarationValue, bool>> expr = e => e.IdDeclarations == idDeclaration && e.IdDeclarationParameters == 9 && e.IdDeclarationValues == 3;
                DeclarationValue dv = this.unitOfWork.DeclarationValues.GetFirstOrDefault(expr);
                if (dv != null)
                {
                    terminate = true;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return terminate;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
