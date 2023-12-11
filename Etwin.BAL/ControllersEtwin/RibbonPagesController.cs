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
    
    public class RibbonPagesController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RibbonPagesController> _logger;
        private readonly BlRibbonPages blRibbonPages = null;

        #endregion

        public RibbonPagesController(ILogger<RibbonPagesController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRibbonPages = new BlRibbonPages(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRibbonPage/{RibbonPages}")]
        public async Task<bool> AddRibbonPage(RibbonsPage RibbonPages)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPages.AddRibbonPage(RibbonPages);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPagess/")]
        public async Task<IList<RibbonsPage>> GetRibbonPages()
        {
            IList<RibbonsPage> lstRibbonPages = new List<RibbonsPage>();
            try
            {
                lstRibbonPages = this.blRibbonPages.GetRibbonPages();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRibbonPages;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPage/{RibbonPagesName}")]
        public async Task<BindingList<RibbonsPage>> GetRibbonPage(string RibbonPagesName)
        {
            BindingList<RibbonsPage> bindingList = new BindingList<RibbonsPage>();
            try
            {
                bindingList = this.blRibbonPages.GetRibbonPage(RibbonPagesName);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingList;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPage/{idRibbonPages}")]
        public async Task<RibbonsPage> GetRibbonPage(int idRibbonPages)
        {
            RibbonsPage ribbonPage = new RibbonsPage();
            try
            {
                ribbonPage = this.blRibbonPages.GetRibbonPage(idRibbonPages);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return ribbonPage;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRibbonPageId/{name}")]
        public async Task<int> GetRibbonPageId(string name)
        {
            int id = 0;
            try
            {
                id = this.blRibbonPages.GetRibbonPageId(name);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return id;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRibbonPages/{ribbonGroup}")]
        public async Task<bool> UpdateRibbonPages(RibbonsPage ribbonGroup)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPages.UpdateRibbonPage(ribbonGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRibbonPages/{ribbonGroup}")]
        public async Task<bool> DeleteRibbonPages(RibbonsPage ribbonGroup)
        {
            bool result = true;
            try
            {
                result = this.blRibbonPages.DeleteRibbonPage(ribbonGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}