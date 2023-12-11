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
    public class BlCompanyTheme : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlCompanyTheme(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public IList<CompanyTheme> GetCompanyTheme()
        {
            IList<CompanyTheme> lstCompanyTheme = new List<CompanyTheme>();
            try
            {
                lstCompanyTheme = this.unitOfWork.CompanyTheme.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstCompanyTheme;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
