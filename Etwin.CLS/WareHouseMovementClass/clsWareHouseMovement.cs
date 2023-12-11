using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.CLS.WareHouseMovementClass
{
    public class clsWareHouseMovement
    {
        public void InsertMovement(ProcessesList prl, Bom b)
        {
            try
            {
                //I insert a commitment movement
                BlWarehouseMovement blWarehouseMovement = new BlWarehouseMovement();
                BlWarehouseItem blWarehouseItem = new BlWarehouseItem();
                WarehouseItem wi = blWarehouseItem.GetWarehouseItemByIdItem((int)prl.IdItem);
                WarehouseMovement wm = new WarehouseMovement();
                wm = blWarehouseMovement.ExistWarehouseMovement((int)prl.IdItem, 7, 1);
                if (wm.Id == null)
                {
                    wm.IdWareHouseItem = (int)prl.IdItem;
                    wm.IdWareHouseMovementType = 7;
                    wm.IdWarehouse = 1;
                    wm.Quantity = (int)b.Quantity;
                    blWarehouseMovement.AddWarehouseMovement(wm);
                }
                else
                {
                    //if it already exists I just update it
                    wm.Quantity = wm.Quantity + (int)b.Quantity;
                    blWarehouseMovement.UpdateWarehouseMovement(wm);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

    }
}
