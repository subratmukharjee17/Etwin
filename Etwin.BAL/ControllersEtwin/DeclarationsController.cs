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
    
    public class DeclarationsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<DeclarationsController> _logger;
        private readonly BlDeclarations blDeclarations = null;

        #endregion

        public DeclarationsController(ILogger<DeclarationsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blDeclarations = new BlDeclarations(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddDeclarations/{declaration}")]
        public async Task AddDeclarations(Declaration declaration)
        {
            try
            {
                this.blDeclarations.AddDeclarations(declaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetDeclaration/{idDeclaration}")]
        public async Task<BindingList<Declaration>> GetDeclaration(int idDeclaration)
        {
            BindingList<Declaration> bindingListDeclaration = new BindingList<Declaration>();
            try
            {
                bindingListDeclaration = this.blDeclarations.GetDeclaration(idDeclaration);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListDeclaration;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetWorkingPhaseDeclaration/{matricola}")]
        public async Task<Declaration> GetWorkingPhaseDeclaration(string matricola)
        {
            Declaration d = new Declaration();
            try
            {
                d = this.blDeclarations.GetWorkingPhaseDeclaration(matricola);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return d;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateDeclarations/{declaration}")]
        public async Task UpdateDeclarations(Declaration declaration)
        {
            try
            {
                this.blDeclarations.UpdateDeclarations(declaration);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteDeclaration/{declaration}")]
        public async Task DeleteDeclaration(Declaration declaration)
        {
            try
            {
                this.blDeclarations.DeleteDeclaration(declaration);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}