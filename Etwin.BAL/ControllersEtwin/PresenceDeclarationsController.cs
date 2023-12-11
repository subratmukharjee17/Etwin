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
    
    public class PresenceDeclarationController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<PresenceDeclaration> _logger;
        private readonly BlPresenceDeclarations blPresenceDeclarations = null;

        #endregion

        public PresenceDeclarationController(ILogger<PresenceDeclaration> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blPresenceDeclarations = new BlPresenceDeclarations(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetOperatorPresence/{operatorCode}")]
        public async Task<BindingList<PresenceDeclaration>> GetOperatorPresence(string operatorCode)
        {
            BindingList<PresenceDeclaration> lstPresence = new BindingList<PresenceDeclaration>();
            try
            {
                lstPresence = this.blPresenceDeclarations.GetOperatorPresence(operatorCode);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstPresence;
        }


        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddDeclaration/{declaration}")]
        public async Task<bool> AddDeclaration(PresenceDeclaration declaration)
        {
            bool result = true;
            try
            {
                result = this.blPresenceDeclarations.AddDeclaration(declaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

    }
}