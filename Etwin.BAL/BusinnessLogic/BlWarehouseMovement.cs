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
    public class BlWarehouseMovement : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlWarehouseMovement(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public WarehouseMovement ExistWarehouseMovement(int iditem, int movementType, int warehouse)
        {
            WarehouseMovement wareHouseMovement = new WarehouseMovement();
            try
            {
                Expression<Func<WarehouseMovement, bool>> expr = e => e.IdWareHouseItem == iditem && e.IdWareHouseMovementType == movementType && e.IdWarehouse == warehouse;
                wareHouseMovement = this.unitOfWork.WarehouseMovement.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return wareHouseMovement;
        }

        public void AddWarehouseMovement(WarehouseMovement movement)
        {
            try
            {
                this.unitOfWork.WarehouseMovement.Add(movement);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void UpdateWarehouseMovement(WarehouseMovement movement)
        {
            try
            {
                this.unitOfWork.WarehouseMovement.Update(movement);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
