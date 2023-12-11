using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class OrdersController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<OrdersController> _logger;
        private readonly BlOrders blOrders = null;

        #endregion

        public OrdersController(ILogger<OrdersController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blOrders = new BlOrders(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetOrders/")]
        public async Task<BindingList<OrderRow>> GetOrders()
        {
            BindingList<OrderRow> bindingListOrders = new BindingList<OrderRow>();
            try
            {
                bindingListOrders = this.blOrders.GetOrders();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListOrders;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetListOrderSP/{idOrder}")]
        public async Task<IList<JProperty>> GetListOrderSP(int? idOrder = null)
        {
            IList<JProperty> lstJProperties = new List<JProperty>();
            try
            {
                lstJProperties = this.blOrders.GetListOrderSP(idOrder);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstJProperties;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetOrderById/{int idProcessList}")]
        public async Task<OrderRow> GetOrderById(int idProcessList)
        {
            OrderRow ord = new OrderRow();
            try
            {
                ord = this.blOrders.GetOrderById(idProcessList);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return ord;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateOrder/{Order}")]
        public async Task UpdateOrder(dynamic Order)
        {
            try
            {
                this.blOrders.UpdateOrder(Order);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetColumnType/{lstColumns}/{nomeColonna}")]
        private async Task<string> GetColumnType(IList<GridsColumn> lstColumns, string nomeColonna)
        {
            string result = "";
            try
            {
               // result = this.blOrders.GetColumnType(lstColumns, nomeColonna);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}