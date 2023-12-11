using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class DeclarationValuesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<DeclarationValuesController> _logger;
        private readonly BlDeclarationValues blDeclarationValues = null;

        #endregion

        public DeclarationValuesController(ILogger<DeclarationValuesController> logger, IConfiguration config)
        { 
            this._config = config;
            _logger = logger;
            this.blDeclarationValues = new BlDeclarationValues(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddDeclarationValue/{declarationValue}")]
        public async Task AddDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.blDeclarationValues.AddDeclarationValue(declarationValue);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetDeclarationValue/{idDeclarationValue}")]
        public async Task<BindingList<DeclarationValue>> GetDeclarationValue(int idDeclarationValue)
        {
            BindingList<DeclarationValue> bindingListDeclarationValue = new BindingList<DeclarationValue>();
            try
            {
                bindingListDeclarationValue = this.blDeclarationValues.GetDeclarationValue(idDeclarationValue);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListDeclarationValue;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateDeclarationValue/{declarationValue}")]
        public async Task UpdateDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.blDeclarationValues.UpdateDeclarationValue(declarationValue);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteDeclarationValue/{declarationValue}")]
        public async Task DeleteDeclarationValue(DeclarationValue declarationValue)
        {
            try
            {
                this.blDeclarationValues.DeleteDeclarationValue(declarationValue);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}