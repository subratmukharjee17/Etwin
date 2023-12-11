using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.GlobalDataRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlOrderParameters : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly GlobalDbContext _db;

        public BlOrderParameters(string cs = null)
        {
            this._db = new GlobalDbContext();
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<OrderParameter> GetOrderParameter(int idOrderParameter)
        {
            IList<OrderParameter> lstOrderParameter = new List<OrderParameter>();
            BindingList<OrderParameter> bindingListOrderParameter = new BindingList<OrderParameter>();
            try
            {
                Expression<Func<OrderParameter, bool>> expr = e => e.IdOrderParameter == idOrderParameter;

                lstOrderParameter = this.unitOfWork.OrderParameters.GetAll(expr).ToList();
                bindingListOrderParameter = new BindingList<OrderParameter>(lstOrderParameter);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListOrderParameter;
        }

        public IList<OrderParameter> GetAllOrderParameter()
        {
            IList<OrderParameter> lstOrderParameter = new List<OrderParameter>();
            try
            {
                lstOrderParameter = this.unitOfWork.OrderParameters.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstOrderParameter;
        }

        public int GetIdOrderParameterByName(string name)
        {
            OrderParameter parameter = new OrderParameter();;
            try
            {
                Expression<Func<OrderParameter, bool>> expr = e => e.OrderParameter1 == name;

                parameter = this.unitOfWork.OrderParameters.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return parameter.IdOrderParameter;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
