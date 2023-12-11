using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using LogDll;
using System;
using System.Linq.Expressions;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlItemParametersCompany : IDisposable
    {
        #region VARS
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;
        #endregion

        #region CONSTRUCTOR
        public BlItemParametersCompany(string cs)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region GET COMPANY PARAMETER BY GLOBAL ID
        public ItemParametersCompany GetParameterCompanyByGlobalId(int globalId)
        {
            ItemParametersCompany itemParametersCompany = new ItemParametersCompany();
            try
            {
                Expression<Func<ItemParametersCompany, bool>> expr = e => e.IdItemParameterGlobal == globalId;
                itemParametersCompany = this.unitOfWork.ItemParameterCompany.GetFirstOrDefault(expr);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return itemParametersCompany;
        }
        #endregion

        #region GET COMPANY PARAMETER BY ID
        public ItemParametersCompany GetParameterCompany(int id)
        {
            ItemParametersCompany itemParametersCompany = new ItemParametersCompany();
            try
            {
                Expression<Func<ItemParametersCompany, bool>> expr = e => e.IdItemParameterCompany == id;
                itemParametersCompany = this.unitOfWork.ItemParameterCompany.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return itemParametersCompany;
        }
        #endregion
    }
}
