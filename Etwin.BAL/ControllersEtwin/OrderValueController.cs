using Etwin.BAL.BusinnessLogic;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class OrderValueController : ControllerBase
    {
        #region VARS

        private readonly IConfiguration _config;
        private readonly ILogger<OrderValueController> _logger;
        private readonly BlOrderValues blValoriCommessa;

        #endregion

        public OrderValueController(ILogger<OrderValueController> logger, IConfiguration config)
        {
            this._logger = logger;
            this._config = config;
            this.blValoriCommessa = new BlOrderValues();
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetOrderValue/{idcommessa}")]
        public async Task<BindingList<OrderValue>> GetOrderValue(int idCommessa)
        {
            BindingList<OrderValue> lstValoriCommessa = new BindingList<OrderValue>();
            try
            {
                lstValoriCommessa = this.blValoriCommessa.GetOrderValue(idCommessa);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            
            return lstValoriCommessa;
        }
    }
}