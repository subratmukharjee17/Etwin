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
    public class BlDeclarationsFurture : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlDeclarationsFurture(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public DeclarationsFuture GetDeclarationFuture(int idProcessList, int idPhase)
        {
            DeclarationsFuture df = null;

            try
            {
                IList < DeclarationsFuture> lst = new List < DeclarationsFuture>();
                Expression<Func<DeclarationsFuture, bool>> expr = e => e.IdProcessList == idProcessList && e.IdPhaseCompany == idPhase;
                lst =this.unitOfWork.DeclarationsFuture.GetAll(expr,null, "OperatorCodeNavigation,IdPhaseNavigation").ToList();
                if (lst.Count > 0)
                {
                    df = lst.OrderByDescending(x => x.DeclarationDate).First();
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return df;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
