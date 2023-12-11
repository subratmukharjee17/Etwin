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
    public class BlOrderValues : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlOrderValues(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddOrderValue(OrderValue order)
        {
            try
            {
                this.unitOfWork.OrderValue.Add(order);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }


        public BindingList<OrderValue> GetOrderValue(int idOrderRow)
        {
            IList<OrderValue> lstValoriCommessa = new List<OrderValue>();
            BindingList<OrderValue> bindingListValoriCommessa = new BindingList<OrderValue>();
            try
            {
                Expression<Func<OrderValue, bool>> expr = e => e.IdOrderRow == idOrderRow;

                lstValoriCommessa = this.unitOfWork.OrderValue.GetAll(expr).ToList();
                bindingListValoriCommessa = new BindingList<OrderValue>(lstValoriCommessa);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListValoriCommessa;
        }

        public IList<OrderValue> GetOrderValueByIdOrderRow(int idOrderRow)
        {
            IList<OrderValue> lstValori = new List<OrderValue>();
            try
            {
                Expression<Func<OrderValue, bool>> expr = e => e.IdOrderRow == idOrderRow;

                lstValori = this.unitOfWork.OrderValue.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstValori;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
