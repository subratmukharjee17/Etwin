using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class GenericController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<GenericController> _logger;
        private readonly BlGeneric blGeneric = null;

        #endregion

        public GenericController(ILogger<GenericController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blGeneric = new BlGeneric(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAll/{sqlQuery}")]
        public async Task<IList<T>> GetAll<T>(string sqlQuery)
        {
            IList<T> lstResult = new List<T>();
            try
            {
                lstResult = this.blGeneric.GetAll<T>(sqlQuery);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstResult;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/ExecQuery/{query}")]
        public async Task<BindingList<object>> ExecQuery(string query)
        {
            BindingList<object> result = new BindingList<object>();
            try
            {
                result = this.blGeneric.ExecQuery(query);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/CheckDbConnection/")]
        public async Task<bool> CheckDbConnection()
        {
            bool result = new bool();
            try
            {
                result = this.blGeneric.CheckDbConnection();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/ExecuteSqlQuery/{sqlQuery}/{param}")]
        public async Task<IList<T>> ExecuteSqlQuery<T>(string sqlQuery, DynamicParameters param = null)
        {
            IList<T> result = new List<T>();
            try
            {
                result = this.blGeneric.ExecuteSqlQuery<T>(sqlQuery, param);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    
    }
}