using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class KanBanController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<KanBanController> _logger;
        private readonly BlKanBan blKanBan = null;

        #endregion

        public KanBanController(ILogger<KanBanController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blKanBan = new BlKanBan(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetKanBanBoard/{idBoard}")]
        public async Task<KanBanBoard> GetKanBanBoard(int idBoard)
        {
            KanBanBoard board = new KanBanBoard();
            try
            {
                board = this.blKanBan.GetKanBanBoard(idBoard);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return board;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetListKanBanGroup/{idBoard}")]
        public async Task<IList<KanBanGroup>> GetListKanBanGroup(int idBoard)
        {
            IList<KanBanGroup> lstGroup = new List<KanBanGroup>();
            try
            {
                lstGroup = this.blKanBan.GetListKanBanGroup(idBoard);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstGroup;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetListKanBanItem/{idGroup}")]
        public async Task<IList<KanBanItem>> GetListKanBanItem(int idGroup)
        {
            IList<KanBanItem> lstItem = new List<KanBanItem>();
            try
            {
                lstItem = this.blKanBan.GetListKanBanItem(idGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstItem;
        }
    }
}