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
    
    public class RibbonsPageGroupsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RibbonsPageGroupsController> _logger;
        private readonly BlRibbonPageGroups blRibbonsPageGroups = null;

        #endregion

        public RibbonsPageGroupsController(ILogger<RibbonsPageGroupsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRibbonsPageGroups = new BlRibbonPageGroups(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRibbonPageGroup/{RibbonsPageGroups}")]
        public async Task<bool> AddRibbonPageGroup(RibbonsPageGroup RibbonsPageGroups)
        {
            bool result = true;
            try
            {
                result = this.blRibbonsPageGroups.AddRibbonPageGroup(RibbonsPageGroups);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPageGroups/")]
        public async Task<IList<RibbonsPageGroup>> GetRibbonPageGroups()
        {
            IList<RibbonsPageGroup> lstRibbonsPageGroupButtons = new List<RibbonsPageGroup>();
            try
            {
                lstRibbonsPageGroupButtons = this.blRibbonsPageGroups.GetRibbonPageGroups();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRibbonsPageGroupButtons;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPageGroups/{idRibbonPage}")]
        public async Task<IList<RibbonsPageGroup>> GetRibbonPageGroups(int idRibbonPage)
        {
            IList<RibbonsPageGroup> lstRibbonsPageGroupButtons = new List<RibbonsPageGroup>();
            try
            {
                lstRibbonsPageGroupButtons = this.blRibbonsPageGroups.GetRibbonPageGroups(idRibbonPage);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRibbonsPageGroupButtons;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonsPageGroupButton/{ribbonPageGroupName}")]
        public async Task<BindingList<RibbonsPageGroup>> GetRibbonsPageGroupButtons(string ribbonPageGroupName)
        {
            BindingList<RibbonsPageGroup> bindingList = new BindingList<RibbonsPageGroup>();
            try
            {
                bindingList = this.blRibbonsPageGroups.GetRibbonPageGroup(ribbonPageGroupName);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingList;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPageGroup/{idRibbonPageGroup}")]
        public async Task<RibbonsPageGroup> GetRibbonPageGroup(int idRibbonPageGroup)
        {
            RibbonsPageGroup RibbonBarItem = new RibbonsPageGroup();
            try
            {
                RibbonBarItem = this.blRibbonsPageGroups.GetRibbonPageGroup(idRibbonPageGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return RibbonBarItem;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPageGroupId/{name}")]
        public async Task<int> GetRibbonPageGroupId(string name)
        {
            int id = 0;
            try
            {
                id = this.blRibbonsPageGroups.GetRibbonPageGroupId(name);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return id;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRibbonPageGroup/{ribbonGroup}")]
        public async Task<bool> UpdateRibbonPageGroup(RibbonsPageGroup ribbonGroup)
        {
            bool result = true;
            try
            {
                result = this.blRibbonsPageGroups.UpdateRibbonPageGroup(ribbonGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRibbonPageGroup/{ribbonGroup}")]
        public async Task<bool> DeleteRibbonPageGroup(RibbonsPageGroup ribbonGroup)
        {
            bool result = true;
            try
            {
                result = this.blRibbonsPageGroups.DeleteRibbonPageGroup(ribbonGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}