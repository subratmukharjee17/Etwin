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
    
    public class MacroProcessesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<MacroProcessesController> _logger;
        private readonly BlMacroProcesses blMacroProcesses = null;

        #endregion

        public MacroProcessesController(ILogger<MacroProcessesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blMacroProcesses = new BlMacroProcesses(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetMacroProcess/{idMacroProcess}")]
        public async Task<BindingList<MacroProcess>> GetMacroProcess(int idMacroProcess)
        {
            BindingList<MacroProcess> bindingListMacroProcess = new BindingList<MacroProcess>();
            try
            {
                bindingListMacroProcess = this.blMacroProcesses.GetMacroProcess(idMacroProcess);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListMacroProcess;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAllMacroProcess/{lst}")]
        public async Task<IList<MacroProcess>> GetMacroProcess(IList<int> lst)
        {
            IList<MacroProcess> lstMacroProcess = new List<MacroProcess>();
            try
            {
                lstMacroProcess = this.blMacroProcesses.GetAllMacroProcess(lst);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstMacroProcess;
        }
    }
}