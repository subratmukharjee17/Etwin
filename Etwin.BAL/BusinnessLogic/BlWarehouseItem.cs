using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using System;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.DataRepository;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlWarehouseItem : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlWarehouseItem(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public WarehouseItem GetWarehouseItemById(int idwarehouse)
        {
            WarehouseItem item = new WarehouseItem();
            try
            {
                Expression<Func<WarehouseItem, bool>> expr = e => e.Id == idwarehouse;

                item = this.unitOfWork.WarehouseItem.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return item;
        }

        public WarehouseItem GetWarehouseItemByIdItem(int idItem)
        {
            WarehouseItem item = new WarehouseItem();
            try
            {
                Expression<Func<WarehouseItem, bool>> expr = e => e.IdItem == idItem;

                item = this.unitOfWork.WarehouseItem.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return item;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
