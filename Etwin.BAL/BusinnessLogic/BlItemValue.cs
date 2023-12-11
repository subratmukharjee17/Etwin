using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlItemValue : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlItemValue(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddItemValue(ItemValue i)
        {
            try
            {
                this.unitOfWork.ItemValue.Add(i);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public IList<ItemValue> GetItemValueByItem(int idItem)
        {
            IList<ItemValue> lstIV = new List<ItemValue>();

            try
            {
                Expression<Func<ItemValue, bool>> expr = e => e.IdItem == idItem;

                lstIV = this.unitOfWork.ItemValue.GetAll(expr).ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstIV;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
