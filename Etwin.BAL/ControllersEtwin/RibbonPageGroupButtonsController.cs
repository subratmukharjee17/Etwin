using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class RibbonPageGroupButtonsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RibbonPageGroupButtonsController> _logger;
        private readonly BlRibbonsPageGroupButtons blRibbonPageGroupButtons = null;

        #endregion

        public RibbonPageGroupButtonsController(ILogger<RibbonPageGroupButtonsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRibbonPageGroupButtons = new BlRibbonsPageGroupButtons(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRibbonsPageGroupButton/{ribbonPageGroupButtons}")]
        public async Task<bool> AddRibbonsPageGroupButton(RibbonsPageGroupButton ribbonPageGroupButtons)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPageGroupButtons.AddRibbonsPageGroupButton(ribbonPageGroupButtons);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonsPageGroupButtons/")]
        public async Task<IList<RibbonsPageGroupButton>> GetRibbonsPageGroupButtons()
        {
            IList<RibbonsPageGroupButton> lstRibbonsPageGroupButtons = new List<RibbonsPageGroupButton>();
            try
            {
                lstRibbonsPageGroupButtons = this.blRibbonPageGroupButtons.GetRibbonsPageGroupButtons();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRibbonsPageGroupButtons;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonsPageGroupButton/{toolbarRibbonGroupButtonName}")]
        public async Task<BindingList<RibbonsPageGroupButton>> GetRibbonsPageGroupButtons(string toolbarRibbonGroupButtonName)
        {
            BindingList<RibbonsPageGroupButton> bindingList = new BindingList<RibbonsPageGroupButton>();
            try
            {
                bindingList = this.blRibbonPageGroupButtons.GetRibbonsPageGroupButton(toolbarRibbonGroupButtonName);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingList;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonsPageGroupButton/{idRibbonsPageGroupButton}")]
        public async Task<RibbonsPageGroupButton> GetRibbonsPageGroupButton(int idRibbonsPageGroupButton)
        {
            RibbonsPageGroupButton RibbonBarItem = new RibbonsPageGroupButton();
            try
            {
                RibbonBarItem = this.blRibbonPageGroupButtons.GetRibbonsPageGroupButton(idRibbonsPageGroupButton);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return RibbonBarItem;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRibbonsPageGroupButton/{toolbarRibbonGroupButton}")]
        public async Task<bool> UpdateRibbonsPageGroupButton(RibbonsPageGroupButton toolbarRibbonGroupButton)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPageGroupButtons.UpdateRibbonsPageGroupButton(toolbarRibbonGroupButton);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRibbonsPageGroupButton/{toolbarRibbonGroupButton}")]
        public async Task<bool> DeleteRibbonsPageGroupButton(RibbonsPageGroupButton toolbarRibbonGroupButton)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPageGroupButtons.DeleteRibbonsPageGroupButton(toolbarRibbonGroupButton);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}