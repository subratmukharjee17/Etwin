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
    
    public class ProcessesListController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ProcessesListController> _logger;
        private readonly BlProcessesLists blProcessesList = null;

        #endregion

        public ProcessesListController(ILogger<ProcessesListController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blProcessesList = new BlProcessesLists(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetProcessesList/{idProcessesList}")]
        public async Task<BindingList<ProcessesList>> GetProcessesList(int idProcessesList)
        {
            BindingList<ProcessesList> lstProcessesList = new BindingList<ProcessesList>();
            try
            {
                lstProcessesList = this.blProcessesList.GetProcessesList(idProcessesList);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstProcessesList;
        }
    }
}