using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class CustomersController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<CustomersController> _logger;
        private readonly BlCustomers blCustomers = null;

        #endregion

        public CustomersController(ILogger<CustomersController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blCustomers = new BlCustomers(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetCustomer/{idCustomer}")]
        public async Task<BindingList<Customer>> GetCustomer(int idCustomer)
        {
            BindingList<Customer> bindingListCustomer = new BindingList<Customer>();
            try
            {
                bindingListCustomer = this.blCustomers.GetCustomer(idCustomer);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListCustomer;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetIdCustomerByName/{name}")]
        public async Task<int> GetIdCustomerByName(string name)
        {
            int id = 0;
            try
            {
                id = this.blCustomers.GetIdCustomerByName(name);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return id;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetTopTenCustomer/")]
        public async Task<IList<Customer>> GetTopTenCustomer()
        {
            IList<Customer> lstCustomer = new List<Customer>();
            try
            {
                lstCustomer = this.blCustomers.GetTopTenCustomer();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstCustomer;
        }
    }
}