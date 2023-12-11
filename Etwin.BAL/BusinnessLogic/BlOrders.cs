using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Dynamic;
using ETwin.BAL.FixModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using static ETwin.Helper.Utilities.clsGridUtilities;
using ETwin.Helper.Utilities;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlOrders : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        public readonly ETwinContext _db;

        public BlOrders(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        /// <summary>
        /// LETTURA COMMESSE
        /// </summary>
        /// <returns></returns>
        public BindingList<OrderRow> GetOrders()
        {
            IList<OrderRow> lstOrders = new List<OrderRow>();
            BindingList<OrderRow> bindingListOrders = new BindingList<OrderRow>();
            try
            {
                lstOrders = this.unitOfWork.OrderRow.GetAll(null, null, "").ToList();
                bindingListOrders = new BindingList<OrderRow>(lstOrders);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListOrders;
        }

        public Order GetOrdersById(int id)
        {
            Order orders = new Order();
            try
            {
                Expression<Func<Order, bool>> expr = e => e.Id == id;
                orders = this.unitOfWork.Orders.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return orders;
        }

        public IList<Order> GetAllOrdersOfYear(int anno)
        {
            //clsLog.Info(">>> GET ORDERS - INIZIO");

            IList<Order> lstOrders = new List<Order>();
            try
            {
                Expression<Func<Order, bool>> expr = e => e.Norder.Contains(anno + "/");
                lstOrders = this.unitOfWork.Orders.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstOrders;
        }

        public IList<OrderRow> GetAllOrderRow()
        {

            IList<OrderRow> lstOrders = new List<OrderRow>();
            try
            {
                lstOrders = this.unitOfWork.OrderRow.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstOrders;
        }

        public int GetIdOrder(string code)
        {
            int id = 0;
            OrderRow o = new OrderRow();
            try
            {
                Expression<Func<OrderRow, bool>> expr = e => e.IdOrderParentNavigation.Norder == code;
                o = this.unitOfWork.OrderRow.GetFirstOrDefault(expr);
                id = o.IdOrderRow;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return id;
        }

        public IList<JProperty> GetListOrderSP(int? idOrder = null)
        {
            IList<OrderRow> lstOrderSP = new List<OrderRow>();
            IList<JProperty> lstJProperties = new List<JProperty>();
            try
            {
                Expression<Func<OrderRow, bool>> expr = null;
                if (idOrder != null)
                {
                    expr = e => e.IdItem == idOrder;
                }

                lstOrderSP = new List<OrderRow>(this.unitOfWork.OrderRow.GetAll(expr, null, "").ToList());
                using (SP_Call spCall = new SP_Call(this._db))
                {
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    if (idOrder != null)
                    {
                        dP.Add("idOrder", idOrder);
                    }
                    dP.Add("idAmbito", 1);
                    // CALL SP : RITORNA UNA STRINGA JSON CON I PARAMETRI COMMESSA IN FORMATO COLONNE, NON RIGHE
                    string valoriCommessaJson = spCall.OneRecordJson("spGetOrderWithPhase", dP);
                    if (!string.IsNullOrEmpty(valoriCommessaJson) && valoriCommessaJson != "[]")
                    {
                        IList<JObject> valoriCommessa = JsonConvert.DeserializeObject<IList<JObject>>(valoriCommessaJson);
                        lstJProperties = valoriCommessa.Properties().ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstJProperties;
        }

        public OrderRow GetOrderById(int idOrder)
        {
            OrderRow ord = new OrderRow();
            try
            {
                Expression<Func<OrderRow, bool>> expr = e => e.IdOrderRow == idOrder;
                ord = this.unitOfWork.OrderRow.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return ord;
        }

        /// <summary>
        /// UPDATE ORDER
        /// </summary>
        /// <param name="Order"></param>
        public void UpdateOrder(dynamic Order)
        {
            //clsLog.Info(">>> UPDATEORDER - INIZIO");

            try
            {
                // OGGETTO COMMESSA DA AGGIORNARE
                OrderRow orderToUpdate = new OrderRow();

                // LISTA PROPRIETA' MODELLO Commesse
                IList<PropertyInfo> modInfo = clsDynamicClass.GetModelProperties<OrderRow>();
                foreach (PropertyInfo pi in modInfo)
                {
                    // RICAVO IL VALORE DELLA PROPRIETA' pi DALL'OGGETTO DINAMICO commessa 
                    object objValore = clsDynamicClass.GetModelPropertyValue<dynamic>(Order, pi.Name);
                    if (objValore != null)
                    {
                        // SE LO TROVO LO SETTO SULL'OGGETTO commessaToUpdate 
                        clsDynamicClass.SetModelPropertyValue<OrderRow>(orderToUpdate, pi.Name, objValore);
                    }
                }

                // AGGIORNAMENTO A DB
                this.unitOfWork.OrderRow.Update(orderToUpdate);
            }
            catch (Exception ex)
            {
                clsLog.Error("UpdateOrder - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATEORDER - FINE");
            }
        }

        public void AddOrderRow(OrderRow order)
        {
            try
            {
                this.unitOfWork.OrderRow.Add(order);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void AddOrders(Order order)
        {
            try
            {
                this.unitOfWork.Orders.Add(order);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstColumns"></param>
        /// <param name="nomeColonna"></param>
        /// <returns></returns>
        //public string GetColumnType(IList<GridsColumn> lstColumns, string nomeColonna)
        //{
        //    string result = string.Empty;

        //    ////clsLog.Info(">>> GETCOLUMNTYPE - INIZIO");

        //    try
        //    {
        //        GridsColumn column = lstColumns.Where(g => g.NomeColonna == nomeColonna).FirstOrDefault();
        //        if (column != null && column.IdTipoColonnaNavigation != null)
        //        {
        //            GridsColumnsType columnsType = column.IdTipoColonnaNavigation;
        //            result = columnsType.Valore;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    finally
        //    {
        //        ////clsLog.Info(">>> GETCOLUMNTYPE - FINE");
        //    }
        //    return result;
        //}

        #region GET ORDER ROW BY STATES
        public IList<OrderRow> GetOrderRowsByState(int state)
        {
            IList<OrderRow> lstOrders = new List<OrderRow>();
            try
            {
                Expression<Func<OrderRow, bool>> expr = e => e.IdOrderStates == state;
                lstOrders= this.unitOfWork.OrderRow.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstOrders;
        }
        #endregion
        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
