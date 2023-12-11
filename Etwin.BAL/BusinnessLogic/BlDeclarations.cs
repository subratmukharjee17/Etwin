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
    public class BlDeclarations : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlDeclarations(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddDeclarations(Declaration declaration)
        {
            try
            {
                this.unitOfWork.Declarations.Add(declaration);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public BindingList<Declaration> GetDeclaration(int idDeclaration)
        {
            IList<Declaration> lstDeclaration = new List<Declaration>();
            BindingList<Declaration> bindingListDeclaration = new BindingList<Declaration>();
            try
            {
                Expression<Func<Declaration, bool>> expr = e => e.IdDeclaration == idDeclaration;

                lstDeclaration = this.unitOfWork.Declarations.GetAll(expr).ToList();
                bindingListDeclaration = new BindingList<Declaration>(lstDeclaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListDeclaration;
        }

        public Declaration GetWorkingPhaseDeclaration(string matricola)
        {
            Declaration declaration = new Declaration();
            IList<Declaration> lstDeclaration = new List<Declaration>();

            try
            {
                Expression<Func<Declaration, bool>> expr = e => e.OperatorCode == matricola;
                lstDeclaration = (this.unitOfWork.Declarations.GetAll(expr, null)).OrderByDescending(g => g.DeclarationDate).ToList();
                declaration = lstDeclaration.First();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return declaration;
        }

        public void UpdateDeclarations(Declaration declaration)
        {
            try
            {
                this.unitOfWork.Declarations.Update(declaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void DeleteDeclaration(Declaration declaration)
        {
            try
            {
                this.unitOfWork.Declarations.Remove(declaration);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        
        public IList<Declaration> GetDeclarationClose(int idProcessList, int idPhase)
        {
            IList<Declaration> lstDeclaration = new List<Declaration>();
            //try
            //{
            //    Expression<Func<Declaration, bool>> expr = e => e.IdProcessList == idProcessList && e.IdPhase == idPhase;
            //    lstDeclaration = this.unitOfWork.Declarations.GetAll(expr, null).ToList();
            //}
            //catch (Exception ex)
            //{
            //    clsLog.Error(ex.ToString());
            //}
            return lstDeclaration;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
